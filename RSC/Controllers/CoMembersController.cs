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

namespace RSC.Controllers
{
    public class CoMembersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoMembersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
            Mapper.Initialize(cfg => { });
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var studentCouncilId = db.StudentsCouncils.Where(s => s.ApplicationUserId == userId).Select(s => s.Id).FirstOrDefault();
            var coMembers = db.CoMembers.Where(m => m.StudentsCouncilId == studentCouncilId).ToList();
            return View(coMembers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CoMember());
        }

        [HttpPost]
        public IActionResult Create(CoMember model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var studentCouncilId = db.StudentsCouncils.Where(s => s.ApplicationUserId == userId).Select(s => s.Id).FirstOrDefault();
                model.StudentsCouncilId = studentCouncilId;
                db.CoMembers.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "CoMembers");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = db.CoMembers.Where(m => m.Id == id).FirstOrDefault();
            if (member != null)
            {
                return View(member);
            }
            return RedirectToAction("Index", "CoMembers");
        }

        [HttpPost]
        public IActionResult Edit(CoMember model)
        {
            if (ModelState.IsValid)
            {
                db.CoMembers.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index", "CoMembers");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var member = db.CoMembers.Where(m => m.Id == id).FirstOrDefault();
            if (member != null)
            {
                return View(member);
            }
            return RedirectToAction("Index", "CoMembers");
        }
        
        public IActionResult Delete(int id)
        {
            var member = db.CoMembers.Where(m => m.Id == id).FirstOrDefault();
            if (member != null)
            {
                db.CoMembers.Remove(member);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "CoMembers");
        }
    }
}