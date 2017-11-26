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
using Microsoft.EntityFrameworkCore;

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
            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id" , "Name");
            model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id , Name = direct.Name}).ToList(), "Id", "Name");
            model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EventCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
            model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
            model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
            return View(model);
        }
    }
}