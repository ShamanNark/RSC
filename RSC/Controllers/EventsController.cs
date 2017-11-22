using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Controllers.Models.EventsViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSC.Data;
using Microsoft.AspNetCore.Identity;
using RSC.Models;
using AutoMapper;

namespace RSC.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
            //Mapper.Initialize();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var model = new EventCreateViewModel();
            model.Regions = new SelectList(new[] { "Регион 1", "Регион 2", "Регион 3", "50", "100", "1000" }, "Регион 2");
            model.EventDirections = new SelectList(new[] { "Наука", "Спорт", "Покушать", "Поспать", "100", "1000" }, "Наука");
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EventCreateViewModel model)
        {
            return View();
        }
    }
}