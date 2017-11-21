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
            Mapper.Initialize(cfg => {
                                        cfg.CreateMap<University, OOBO>();
                                     });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userid = _userManager.GetUserId(User);
            var OOBO = db.Universities.Where(university => university.ApplicationUserId == userid).FirstOrDefault();
            if(OOBO == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Надо будет сделать
            //var student = db.StudentsCouncils.Where(council => council.UniversityId == OOBO.Id).FirstOrDefault();

            var model = new CreatePRDSOViewModel
            {
                Leaeder = Mapper.Map<OOBO>(OOBO),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreatePRDSOViewModel model)
        {
            return View();
        }
    }
}