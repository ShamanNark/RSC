using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using RSC.Data;
using Microsoft.EntityFrameworkCore;
using RSC.Controllers.Models.PublicNewsInfoViewModels;
using RSC.Data.DbModels;

namespace RSC.Controllers
{
    public class PublicEventsInfoController : Controller
    {
        private ApplicationDbContext db;
        private readonly IHostingEnvironment _appEnvironment;
        public PublicEventsInfoController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PublicEventInformation, PublicNewsInfoViewModel>();
                cfg.CreateMap<PublicNewsInfoViewModel, PublicEventInformation>();
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int eventId)
        {
            var eventdb = db.Events.Include(e => e.Prdso.Status).FirstOrDefault(e => e.Id == eventId);
            if(eventdb != null)
            {
                if(eventdb.Prdso.Status.Name != "Approved")
                {
                    return RedirectToAction("Index", "Profile");
                }
            }

            var publicEvent = db.PublicEventInformations.FirstOrDefault(info => info.EventId == eventId);
            var model = publicEvent != null
                ? Mapper.Map<PublicNewsInfoViewModel>(publicEvent)
                : new PublicNewsInfoViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PublicNewsInfoViewModel model)
        {
            var eventdb = db.Events.Include(e => e.Prdso.Status).FirstOrDefault(e => e.Id == model.EventId);
            if (eventdb != null)
            {
                if (eventdb.Prdso.Status.Name != "Approved")
                {
                    return RedirectToAction("Index", "Profile");
                }
            }
            var dbmodel = Mapper.Map<PublicEventInformation>(model);
            var dowloadFiles = new Helper.DownloadFiles(db, _appEnvironment);
            if (model.FotoFile != null)
            {
                var fotoFileId = await dowloadFiles.AddImages(model.FotoFile, "/EventPublicFotos/" + eventdb.NameEvent, model.FotoFile.FileName);
                if (fotoFileId != null)
                {
                    dbmodel.FotoId = fotoFileId ?? 0;
                }
            }

            if (model.SmallFotoFile != null)
            {
                var smallFileId = await dowloadFiles.AddImages(model.SmallFotoFile, "/EventPublicSmallFotos/" + eventdb.NameEvent, model.SmallFotoFile.FileName);
                if (smallFileId != null)
                {
                    dbmodel.SmallFotoId = smallFileId ?? 0;
                }
            }
            
            db.PublicEventInformations.Update(dbmodel);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var eventdb = db.PublicEventInformations.Include(e => e.Foto)
                                                    .Include(e => e.Event)
                                                    .Include(e => e.Event.EventType)
                                                    .FirstOrDefault(e => e.EventId == id);
            if (eventdb == null)
            {
                return RedirectToAction("Index", "PublicNewsInfo");
            }
            return View(eventdb);
        }

        //[HttpGet]
        //public IActionResult AnnouncementsBoard(int EventDirectionId = 1, int page = 1)
        //{

        //}
    }
}