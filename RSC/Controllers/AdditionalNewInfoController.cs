using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using Microsoft.EntityFrameworkCore;

namespace RSC.Controllers
{
    public class AdditionalNewInfoController : Controller
    {
        private ApplicationDbContext db;
        public AdditionalNewInfoController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Edit(int eventId)
        {
            var eventdb = db.Events.Include(e => e.Prdso.Status).Where(e => e.Id == eventId).FirstOrDefault();
            if(eventdb != null)
            {
                if(eventdb.Prdso.Status.Name != "Approved")
                {
                    return RedirectToAction("Index", "Profile");
                }
            }
            var model = db.PublicEventInformations.Where(info => info.EventId == eventId).FirstOrDefault() ?? new Data.DbModels.PublicEventInformation();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Data.DbModels.PublicEventInformation model)
        {
            var eventdb = db.Events.Include(e => e.Prdso.Status).Where(e => e.Id == model.EventId).FirstOrDefault();
            if (eventdb != null)
            {
                if (eventdb.Prdso.Status.Name != "Approved")
                {
                    return RedirectToAction("Index", "Profile");
                }
            }
            db.PublicEventInformations.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }
}