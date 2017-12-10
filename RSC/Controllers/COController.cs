using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RSC.Controllers.Models.PRDSOViewModels;
using AutoMapper;
using RSC.Controllers.Models.EventsViewModels;

namespace RSC.Controllers
{
    public class COController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public COController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RSC.Data.DbModels.Event, EventCreateViewModel>();
                cfg.CreateMap<EventCreateViewModel, RSC.Data.DbModels.Event>();
                cfg.CreateMap<List<RSC.Data.DbModels.Event>, List<EventCreateViewModel>>();
                cfg.CreateMap< List<EventCreateViewModel>, List<RSC.Data.DbModels.Event>>();
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult COProfile()
        {
            return View();
        }

        public IActionResult StudStarter()
        {
            return View();
        }

        public IActionResult COMembers()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Students()
        {
            var userId = _userManager.GetUserId(User);
            var coUniversityDataId = db.StudentsCouncils.Where(s => s.ApplicationUserId == userId).Select(s => s.UniversityDataId).FirstOrDefault();
            var students = db.Students.Include(s => s.ApplicationUser).Where(s => s.UniversityDataId == coUniversityDataId).ToList();
            return View(students);
        }

        public IActionResult PrdsoEvents()
        {
            var userId = _userManager.GetUserId(User);
            var studentCouncilId = db.StudentsCouncils.Where(s => s.ApplicationUserId == userId).Select(s => s.Id).FirstOrDefault();
            var prdsoEvents = db.Events.Include(e => e.Costs).Include(e => e.TargetIndicators).Where(e => e.Prdso.StudentsCouncilId == studentCouncilId).ToList();
            var modelEvents = new List<EventCreateViewModel>();
            foreach (var prdsoevent in prdsoEvents)
            {
                var mapperEvent = Mapper.Map<EventCreateViewModel>(prdsoevent);
                modelEvents.Add(mapperEvent);
            }
            return View(modelEvents);
        }
    }
}