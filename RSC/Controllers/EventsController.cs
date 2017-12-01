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
            model.EventTypes = new SelectList(db.PrdsoTypes.Select(prdso => new { Id = prdso.Id, Name = prdso.Name }).ToList(), "Id", "Name");
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
            model.EventTypes = new SelectList(db.PrdsoTypes.Select(prdso => new { Id = prdso.Id, Name = prdso.Name }).ToList(), "Id", "Name");
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
                model.EventTypes = new SelectList(db.PrdsoTypes.Select(prdso => new { Id = prdso.Id, Name = prdso.Name }).ToList(), "Id", "Name");
                return View(model);
            }
            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public IActionResult Edit(EventCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var dbEvent = db.Events.Include(e => e.Costs).Include(e => e.TargetIndicators).Where(e => e.Id == model.Id).FirstOrDefault();
                if(dbEvent != null)
                {
                    dbEvent.CountImplementaionEvents = model.CountImplementaionEvents;
                    dbEvent.CountOOVO = model.CountOOVO;
                    dbEvent.EventDirectionId = model.EventDirectionId;
                    dbEvent.EventTypeId = model.EventTypeId;
                    dbEvent.ExpectedEffectsOfTheEvent = model.ExpectedEffectsOfTheEvent;
                    dbEvent.ImplementationEventsShotInfo = model.ImplementationEventsShotInfo;
                    dbEvent.ImplementationPlan = model.ImplementationPlan;
                    dbEvent.MeasuresToEnsurePublicityEvent = model.MeasuresToEnsurePublicityEvent;
                    dbEvent.NameEvent = model.NameEvent;
                    dbEvent.NumberOfParticipantsInThisOOVO = model.NumberOfParticipantsInThisOOVO;
                    dbEvent.NumberOfParticipantsWithoutSubsidy = model.NumberOfParticipantsWithoutSubsidy;
                    dbEvent.NumberOfParticipantsWithSubsidies = model.NumberOfParticipantsWithSubsidies;
                    dbEvent.OrderOfEventManagement = model.OrderOfEventManagement;
                    dbEvent.PurposeOfTheEvent = model.PurposeOfTheEvent;
                    dbEvent.RegionId = model.RegionId;
                    dbEvent.StartDateTime = model.StartDateTime;
                    dbEvent.StopDateTime = model.StopDateTime;
                    dbEvent.TotalNumberOfParticipants = model.TotalNumberOfParticipants;
                    dbEvent.ImplementationEventsShotInfo = model.ImplementationEventsShotInfo;


                    var allCosts = dbEvent.Costs.ToList();
                    var addCosts = model.Costs.Where(cost => cost.Id == 0);
                    var exitCosts = model.Costs.Where(cost => cost.Id > 0);
                    var removeCosts = allCosts.Where(cost => !exitCosts.Select(c => c.Id).Contains(cost.Id) );

                    db.Costs.AddRange(addCosts.Select(cost => new Data.DbModels.Cost
                    {
                        EventId = model.Id,
                        СostDivisionId = cost.СostDivisionId,
                        Unit = cost.Unit,
                        UnitPrice = cost.UnitPrice,
                        Note = cost.Note,
                        AmountCost = cost.AmountCost,
                        Count = cost.Count,
                        DirectionOfCost = cost.DirectionOfCost                        
                    }).ToList());

                    db.Costs.RemoveRange(removeCosts);
                    foreach (var exitCost in exitCosts)
                    {
                        var editCost = db.Costs.Where(cost => cost.Id == exitCost.Id).FirstOrDefault();
                        editCost.AmountCost = exitCost.AmountCost;
                        editCost.Count = exitCost.Count;
                        editCost.DirectionOfCost = exitCost.DirectionOfCost;
                        editCost.Note = exitCost.Note;
                        editCost.Unit = exitCost.Unit;
                        editCost.UnitPrice = exitCost.UnitPrice;
                    }

                    var allIndicators = dbEvent.TargetIndicators.ToList();
                    var addIndicators = model.TargetIndicators.Where(target => target.Id == 0);
                    var exitIndicators = model.TargetIndicators.Where(target => target.Id > 0);
                    var removeIndicators = allIndicators.Where(indicator => !exitIndicators.Select(ei => ei.Id).Contains(indicator.Id));

                    db.TargetIndicators.AddRange(addIndicators.Select(indicator => new Data.DbModels.TargetIndicator
                    {
                        EventId = model.Id,
                        Name = indicator.Name,
                        PlannedValue = indicator.PlannedValue,
                        BasicValue = indicator.BasicValue,
                        Unit = indicator.Unit
                    }).ToList());

                    db.TargetIndicators.RemoveRange(removeIndicators);
                    foreach (var exitIndicator in exitIndicators)
                    {
                        var editIndicator = db.TargetIndicators.Where(ti => ti.Id == exitIndicator.Id).FirstOrDefault();
                        editIndicator.BasicValue = exitIndicator.BasicValue;
                        editIndicator.Name = exitIndicator.Name;
                        exitIndicator.PlannedValue = exitIndicator.PlannedValue;
                        exitIndicator.Unit = exitIndicator.Unit;
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index", "Profile");
                }
            }
            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
            model.EventDirections = new SelectList(db.EventDirections.Select(direct => new { Id = direct.Id, Name = direct.Name }).ToList(), "Id", "Name");
            model.CostSections = db.CostSections.Include(section => section.CostDivisions).ToList();
            model.EventTypes = new SelectList(db.PrdsoTypes.Select(prdso => new { Id = prdso.Id, Name = prdso.Name }).ToList(), "Id", "Name");
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
                model.EventTypes = new SelectList(db.PrdsoTypes.Select(prdso => new { Id = prdso.Id, Name = prdso.Name }).ToList(), "Id", "Name");
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
            }
            return RedirectToAction("Index", "Profile");
        }

    }
}