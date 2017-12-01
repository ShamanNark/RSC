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
            Mapper.Initialize( cfg => 
            {
                cfg.CreateMap<EventCreateViewModel, Data.DbModels.Event>();
                cfg.CreateMap<Data.DbModels.Event, EventCreateViewModel>();
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var model = new EventCreateViewModel()
            {
                PrdsoId = id
            };            
            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id" , "Name");
            model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id , Name = direct.Name}).ToList(), "Id", "Name");
            model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EventCreateViewModel model)
        {
            model.Id = 0;
            if (ModelState.IsValid)
            {
                var dbEvent = Mapper.Map<EventCreateViewModel, Data.DbModels.Event>(model);
                db.Events.Add(dbEvent);
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
            model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
            model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dbmodel = db.Events.Include(e => e.Costs).Include(e => e.TargetIndicators).Where(e => e.Id == id).FirstOrDefault();
            if (dbmodel != null)
            {
                var model = Mapper.Map<EventCreateViewModel>(dbmodel);
                model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
                model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
                model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public IActionResult Edit(EventCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var dbEvent = db.Events.Where(e => e.Id == model.Id).FirstOrDefault();
                if(dbEvent != null)
                {
                    dbEvent = Mapper.Map<Data.DbModels.Event>(model);
                    db.Update(dbEvent);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Profile");
                }
            }
            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
            model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
            model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var dbmodel = db.Events.Include(e => e.TargetIndicators).Include(e => e.Costs).Where(e => e.Id == id).FirstOrDefault();
            if (dbmodel != null)
            {
                var model = Mapper.Map<EventCreateViewModel>(dbmodel);
                model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
                model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
                model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dbmodel = db.Events.Where(e => e.Id == id).FirstOrDefault();
            if (dbmodel != null)
            {
                db.Events.Remove(dbmodel);
                db.SaveChanges();
                //var model = Mapper.Map<EventCreateViewModel>(dbmodel);
                //model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
                //model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
                //model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
                //return View(model);
            }
            return RedirectToAction("Index", "Profile");
        }

    }
}