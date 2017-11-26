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
            if (oovo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ProfileViewModel
            {
                University = oovo,
                PrdsoTypes = db.PrdsoTypes.ToList()
            };
            return View(model);
        }
    }
}