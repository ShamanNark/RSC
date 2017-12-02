﻿using System;
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

namespace RSC.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var oovo = db.Universities.Include(university => university.ApplicationUser)
                                      .Include(university => university.UniversityData)
                                      .Where(university => university.ApplicationUserId == user.Id).FirstOrDefault();
            var co = db.StudentsCouncils.Include(so => so.ApplicationUser)
                                        .Include(so => so.University)
                                        .Where(so => so.ApplicationUserId == user.Id).FirstOrDefault();
            if (oovo == null && co == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var prdso = oovo != null ? db.PrdsoList.Where(p => p.UniversityId == oovo.Id).FirstOrDefault() :
                                             db.PrdsoList.Include(p => p.University).Where(p => p.University.UniversityDataId == co.EducationalOrganizationId).FirstOrDefault();
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
                Events =  db.Events.Where(e => e.PrdsoId == prdso.Id).ToList()
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

        public IActionResult ProfileList()
        {
            var IndexModel = db.PrdsoList.Select(prdso => new ProfileViewModel
            {
                PrdsoId = prdso.Id,
                University = prdso.University
            }).ToList();
            return View(IndexModel);
        }

        public void ChangeApproved(bool studenApproved, bool universityApproved, int prdsoId)
        {
            var prdsoModel = db.PrdsoList.Where(prdso => prdso.Id == prdsoId).FirstOrDefault();
            if(prdsoModel != null)
            {
                prdsoModel.StudentCouncilApproved = studenApproved;
                prdsoModel.UniversityApproved = universityApproved;
            }
            db.SaveChanges();
        }
    }
}