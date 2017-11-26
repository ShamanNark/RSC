using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Controllers.Models.PRDSOViewModels;
using Microsoft.AspNetCore.Identity;
using RSC.Data;
using RSC.Models;
using AutoMapper;
using RSC.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RSC.Controllers
{
    public class PRDSOController : Controller
    {
        private readonly ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;

        public PRDSOController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var oovo = db.Universities.Include(university => university.ApplicationUser)
                                      .Include(university => university.UniversityData)
                                      .Where(university => university.ApplicationUserId == user.Id).FirstOrDefault();
            if (oovo == null && oovo.ApplicationUser.Status == ApplicationUserStatus.Approved)
            { 
                return RedirectToAction("Index", "Home");
            }

            var model = new Prdso
            {
                UniversityId = oovo.Id,
                University = oovo
            };
            ViewBag.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
            ViewBag.UniversityDatas = new SelectList(db.UniversityDatas.Select(uny => new { Id = uny.Id, Name = uny.UniversityName }), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Data.DbModels.Prdso model)
        {
            if(ModelState.IsValid)
            {
                db.PrdsoList.Add(model);
                db.SaveChanges();
            }
            return View(model);
        }
    }
}