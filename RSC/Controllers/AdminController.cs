using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RSC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;
        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult СonfirmationUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditStatusUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            ViewBag.Statuses = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = true, Text = "Ожидание", Value = "0"},
                new SelectListItem { Selected = false, Text = "Потвержденно", Value = "1"},
                new SelectListItem { Selected = false, Text = "Отказанно", Value = "2"},
            }, "Value", "Text", 0);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditStatusUser(ApplicationUser user)
        {
            var userdb = await _userManager.FindByIdAsync(user.Id);
            userdb.Status = user.Status;
            await db.SaveChangesAsync();
            return RedirectToAction("СonfirmationUsers", "Admin");
        }
    }
}