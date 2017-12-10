using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RSC.Controllers.Models.PRDSOViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RSC.Controllers.Models.CoProfileViewModels;
using RSC.Controllers.Models.EventsViewModels;
using RSC.Data.DbModels;
using Event = RSC.Data.DbModels.Event;

namespace RSC.Controllers
{
    [Authorize(Roles = "ADMIN, CO")]
    public class COController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _appEnvironment;

        public COController(ApplicationDbContext context,
                            UserManager<ApplicationUser> userManager,
                            IHostingEnvironment appEnvironment)
        {
            db = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
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
            var userId = _userManager.GetUserId(User);
            var studentCouncil = db.StudentsCouncils.Include(s => s.UniversityData)
                                                      .Include(s => s.OrderCreationCouncilOfLearners)
                                                      .Include(s => s.ProtocolApprovalStudentAssociations)
                                                      .FirstOrDefault(s => s.ApplicationUserId == userId);

            var prdsoEvents = db.Events.Include(e => e.Costs)
                                       .Include(e => e.TargetIndicators)
                                       .Where(e => e.Prdso.StudentsCouncilId == studentCouncil.Id)
                                       .ToList();

            var files = db.CoPersonalFiles.Include(f => f.File).Where(f => f.StudentCouncilId == studentCouncil.Id).ToList();
            var eventDirections = db.EventDirections.ToList();
            var model = new CoProfileViewModel
            {
                StudentCouncil = studentCouncil,
                EventDirections = eventDirections,
                Events = prdsoEvents,
                Files = files
            };
            return View(model);
        }
        
        //public IActionResult StudStarter()
        //{
        //    return View();
        //}
        

        //public IActionResult Events()
        //{
        //    return View();
        //}

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
            var prdsoEvents = db.Events.Include(e => e.Costs)
                                       .Include(e => e.TargetIndicators)
                                       .Where(e => e.Prdso.StudentsCouncilId == studentCouncilId).ToList();
            var modelEvents = new List<EventCreateViewModel>();
            foreach (var prdsoevent in prdsoEvents)
            {
                var mapperEvent = Mapper.Map<EventCreateViewModel>(prdsoevent);
                modelEvents.Add(mapperEvent);
            }
            return View(modelEvents);
        }

        public JsonResult GetEventByFilter(List<int> eventDirectionIds)
        {
            var userId = _userManager.GetUserId(User);
            var studentCouncilId = db.StudentsCouncils.Where(s => s.ApplicationUserId == userId).Select(s => s.Id).FirstOrDefault();
            List<Data.DbModels.Event> prdsoEvents;
            if (eventDirectionIds.Any())
            {
                prdsoEvents = db.Events.Include(e => e.Costs)
                    .Include(e => e.TargetIndicators)
                    .Where(e => eventDirectionIds
                        .Contains(e.EventDirectionId))
                    .Where(e => e.Prdso.StudentsCouncilId == studentCouncilId)
                    .ToList();
            }
            else
            {
                prdsoEvents = db.Events.Include(e => e.Costs)
                    .Include(e => e.TargetIndicators)
                    .Where(e => e.Prdso.StudentsCouncilId == studentCouncilId)
                    .ToList();
            }
            var model = prdsoEvents.Select(item => new
            {
                eventid = item.Id,
                name = "event",
                date = item.StartDateTime.ToString("yyyy-MM-dd"),
                startdatetime = item.StartDateTime,
                stopdatetime = item.StopDateTime,
                eventname = item.NameEvent
            }).ToArray();
            return new JsonResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var dowloadFiles = new Helper.DownloadFiles(db, _appEnvironment);
                var userId = _userManager.GetUserId(User);
                var studentCouncilId = db.StudentsCouncils.Where(s => s.ApplicationUserId == userId).Select(s => s.Id).FirstOrDefault();
                var coFileId = await dowloadFiles.AddFile(uploadedFile, "/CoPrivateFiles/" + uploadedFile.Name, uploadedFile.FileName);
                if (coFileId != null)
                {
                    var cofileDb = new CoPersonalFile {FileId = coFileId ?? 0, StudentCouncilId = studentCouncilId};
                    db.CoPersonalFiles.Add(cofileDb);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("COProfile");
        }
    }
}