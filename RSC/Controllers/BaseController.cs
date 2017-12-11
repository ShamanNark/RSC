using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using RSC.Models;
using RSC.Data;

namespace RSC.Controllers
{
    public abstract class BaseController : Controller
    {

        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BaseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
            InitStatusPrdso();
        }

        public async Task InitStatusPrdso()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.Status = user.Status == ApplicationUserStatus.Approved ? "Approved" : "Not";
                var prdsoobj = db.PrdsoList.Where(prdso => prdso.University.ApplicationUserId == user.Id || prdso.StudentsCouncil.ApplicationUserId == user.Id).FirstOrDefault();
                ViewBag.HasPrdso = prdsoobj != null ? "True" : "False";
            }
            else
            {
                ViewBag.Status = "Not";
                ViewBag.HasPrdso = "False";
            }

            _userManager.Dispose();
            db.Dispose();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent") &&
                Regex.IsMatch(context.HttpContext.Request.Headers["User-Agent"].FirstOrDefault(), "MSIE 8.0"))
            {
                context.Result = Content("Internet Explorer 8.0 не поддерживается");
            }
            base.OnActionExecuting(context);
        }
    }

}