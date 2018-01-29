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
using RSC.Models;
using Microsoft.AspNetCore.Identity;

namespace RSC.Controllers
{
    public class PublicEventsInfoController : Controller
    {
        private int pageSize = 10;
        private ApplicationDbContext db;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        public PublicEventsInfoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
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
                var fotoFileId = await dowloadFiles.SaveEventPublicFoto(model.FotoFile, eventdb.NameEvent, model.FotoFile.FileName);
                if (fotoFileId != null)
                {
                    dbmodel.FotoId = fotoFileId ?? 0;
                }
            }

            if (model.SmallFotoFile != null)
            {
                var smallFileId = await dowloadFiles.SaveEventPublicSmallFotos(model.SmallFotoFile, eventdb.NameEvent, model.SmallFotoFile.FileName);
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
                                                    .Include(e => e.SmallFoto)
                                                    .Include(e => e.Event)
                                                    .Include(e => e.Event.EventType)
                                                    .Include(e => e.EventSubscribers)
                                                    .ThenInclude(sub => sub.ApplicationUser)
                                                    .FirstOrDefault(e => e.EventId == id);
            if (eventdb == null)
            {
                return RedirectToAction("AnnouncementsBoard", "PublicEventsInfo");
            }
            return View(eventdb);
        }

        [HttpGet]
        public IActionResult AnnouncementsBoard(int EventDirectionId = 1, int page = 1)
        {
            var dbQuery = db.Events.Where(e => e.EventStateId > 0)
                                   .Where(e => e.EventDirectionId == EventDirectionId)
                                   .Include(e => e.PublicEventInformation)
                                   .Include(e => e.PublicEventInformation.SmallFoto)
                                   .AsQueryable();
            var count = dbQuery.Count();
            var viewModel = new IndexAnnouncesViewModel
            {
                SelectedEventDirectionId = EventDirectionId,
                Events = dbQuery.Select(e => new СellAnnonceViewModel
                {
                    Id = e.Id,
                    StartDateTime = e.StartDateTime,
                    StopDateTime = e.StopDateTime,
                    NameEvent = e.NameEvent,
                    Adress = e.Adress,
                    Contacts = e.Contacts,
                    TicketPrice = e.TicketPrice,
                    SmallFotoPath = e.PublicEventInformation.SmallFoto.Path
                }).OrderByDescending(n => n.StartDateTime).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                EventDirections = db.EventDirections.Select(n => new EventDirection
                {
                    Id = n.Id,
                    Name = n.Name
                }).ToList(),
                PageViewModel = new PageViewModel(count, page, pageSize)
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetAnnouncesByDirectionId(int id, DateTime startDateTime, DateTime stopDateTime,
            int page = 1)
        {
            var dbQuery = db.Events.Where(e => e.EventStateId > 0)
                .Where(e => e.EventDirectionId == id)
                .Include(e => e.PublicEventInformation)
                .Include(e => e.PublicEventInformation.SmallFoto)
                .AsQueryable();
            var count = dbQuery.Count();
            var viewModel = new IndexAnnouncesViewModel
            {
                SelectedEventDirectionId = id,
                Events = dbQuery.Select(e => new СellAnnonceViewModel
                {
                    Id = e.Id,
                    StartDateTime = e.StartDateTime,
                    StopDateTime = e.StopDateTime,
                    NameEvent = e.NameEvent,
                    Adress = e.Adress,
                    Contacts = e.Contacts,
                    TicketPrice = e.TicketPrice,
                    SmallFotoPath = e.PublicEventInformation.SmallFoto.Path
                }).OrderByDescending(n => n.StartDateTime).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                EventDirections = db.EventDirections.Select(n => new EventDirection
                {
                    Id = n.Id,
                    Name = n.Name
                }).ToList(),
                PageViewModel = new PageViewModel(count, page, pageSize)
            };

            return PartialView("AnnouncesPartialView", viewModel);
        }

        public IActionResult Subscribe(int eventId)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                db.EventSubscribers.Add(new EventSubscriber
                {
                    ApplicationUserId = userId,
                    PublicEventInformationId = eventId
                });
                db.SaveChanges();
            }
            return RedirectToAction("Details", "PublicEventsInfo", new { id = eventId });
        }
    }
}