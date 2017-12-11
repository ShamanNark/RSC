using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using Microsoft.AspNetCore.Identity;
using RSC.Models;
using AutoMapper;
using RSC.Data.DbModels;
using RSC.Controllers.Models.PRDSOViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using RSC.Controllers.Models.ProfileViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RSC.Controllers
{

    [Authorize(Roles = "ADMIN, OOBO, CO, OPERATOR")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;

        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            Prdso prdso;
            ApplicationUser user = null;
            University oovo = null;
            StudentsCouncil co = null;
            if (id == 0)
            {
                user = await _userManager.GetUserAsync(User);
                oovo = db.Universities.Include(university => university.ApplicationUser)
                                      .Include(university => university.UniversityData).FirstOrDefault(university => university.ApplicationUserId == user.Id);
                co = db.StudentsCouncils.Include(so => so.ApplicationUser)
                                        .Include(so => so.UniversityData).FirstOrDefault(so => so.ApplicationUserId == user.Id);

                if (oovo == null && co == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                prdso = oovo != null ? db.PrdsoList.Include(p => p.University)  
                                                   .Include(p => p.University.UniversityData)
                                                   .Include(p => p.Status)
                                                   .Include(p => p.OrderApprovalRector)
                                                   .Include(p => p.EGRUL).FirstOrDefault(p => p.UniversityId == oovo.Id) :
                                       db.PrdsoList.Include(p => p.University)
                                                   .Include(p => p.University.UniversityData)
                                                   .Include(p => p.Status)
                                                   .Include(p => p.OrderApprovalRector)
                                                   .Include(p => p.EGRUL).FirstOrDefault(p => p.University.UniversityDataId == co.UniversityDataId);
            }
            else
            {
                prdso = db.PrdsoList.Include(p => p.University)
                                    .Include(p => p.University.UniversityData)
                                    .Include(p => p.Status)
                                    .Include(p => p.OrderApprovalRector)
                                    .Include(p => p.EGRUL).FirstOrDefault(p => p.Id == id); 
            }

            if (prdso == null )
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ProfileViewModel
            {
                PrdsoId = prdso.Id,
                University = oovo,
                CO = co,
                Prdso = prdso,
                EventTypes = db.PrdsoTypes.ToList(),
                Events =  db.Events.Where(e => e.PrdsoId == prdso.Id).ToList(),
                EventStatuses = db.EventStatuses.ToList(),
                EventStates = db.EventStates.ToList()
            };
            
            if (user != null)
            {
                ViewBag.Status = user.Status == ApplicationUserStatus.Approved ? "Approved" : "Not";
                ViewBag.HasPrdso = prdso != null ? "True" : "False";
            }
            else
            {
                ViewBag.Status = "Not";
                ViewBag.HasPrdso = "False";
            }

            return View(model);
        }

        [Authorize(Roles = "ADMIN, OPERATOR")]
        public IActionResult ProfileList()
        {
            var prdsoList = db.PrdsoList.Include(p => p.University)
                                        .Include(p => p.Status)
                                        .Include(p => p.University.UniversityData)
                                        .Where(p => p.StatusId > 1).ToList();
            var IndexModel = prdsoList.Select(prdso => new ProfileViewModel
            {
                PrdsoId = prdso.Id,
                Prdso = prdso
            }).ToList();
            ViewBag.PrdsoStatuses = new SelectList(db.PrdsoStatuses.Select(status => new { Id = status.Id, Name = status.Name} ), "Id", "Name");
            return View(IndexModel);
        }

        public void ChangeApproved(bool studenApproved, bool universityApproved, int prdsoId)
        {
            var prdsoModel = db.PrdsoList.FirstOrDefault(prdso => prdso.Id == prdsoId);
            if(prdsoModel != null)
            {
                prdsoModel.StudentCouncilApproved = studenApproved;
                prdsoModel.UniversityApproved = universityApproved;
            }
            db.SaveChanges();
        }

        [Authorize(Roles = "ADMIN, OOBO")]
        public IActionResult SendPrdso(int prdsoid)
        {
            var prdsoModel= db.PrdsoList.Where(prdso => prdso.Id == prdsoid).FirstOrDefault();
            if(prdsoModel != null)
            {
                var prdsostatus = db.PrdsoStatuses.Where(status => status.Name == "Submitted").First();
                prdsoModel.StatusId = prdsostatus.Id; 
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Profile");
        }

        [Authorize(Roles = "ADMIN, OPERATOR")]
        public void ChangeStatusPrdso(int prdsoId , int statusId, string prdsoStatusComment)
        {
            var prdsoModel = db.PrdsoList.Include(prdso => prdso.Events).Where(prdso => prdso.Id == prdsoId).FirstOrDefault();
            if(prdsoModel != null)
            {
                prdsoModel.StatusId = statusId;
                var statusReject = db.PrdsoStatuses.Where(status => status.Name == "Rejected").FirstOrDefault();
                var statusApproved = db.PrdsoStatuses.Where(status => status.Name == "Approved").FirstOrDefault();

                if (statusReject.Id == statusId)
                {
                    prdsoModel.StudentCouncilApproved = false;
                    prdsoModel.UniversityApproved = false;
                    prdsoModel.Events.ForEach(e => e.EventStateId = null);
                }

                //if (statusApproved.Id == statusId)
                //{
                //    var eventState = db.EventStates.Where(e => e.CodeName == "Announcement").First();
                //    prdsoModel.Events.ForEach(e => e.EventStateId = eventState.Id);
                //}

                prdsoModel.PrdsoStatusComment = prdsoStatusComment;
                db.SaveChanges();
            }
        }
    }
}