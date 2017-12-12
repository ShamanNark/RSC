using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Models;
using RSC.Models.HomeViewModels;
using RSC.Models.NewsViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RSC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                News = db.ListObjectNewsNewsRubric.Where(l => l.NewsRubricId == 1).Select(n => new DetailsNewsViewModel
                {
                    Id = n.ObjectNews.Id,
                    Text = n.ObjectNews.Text,
                    Title = n.ObjectNews.Title,
                    HomePageImagePath = n.ObjectNews.HomePageImage,
                    MainImagePath = n.ObjectNews.MainImage,
                    CreateDateTime = n.ObjectNews.CreateDateTime
                }).OrderByDescending(n => n.CreateDateTime).Take(6).ToList(),
            };

            //var user = await _userManager.GetUserAsync(User);
            //if (user != null)
            //{
            //    ViewBag.Status = user.Status == ApplicationUserStatus.Approved ? "Approved" : "Not";
            //    var prdsoobj = db.PrdsoList.Where(prdso => prdso.University.ApplicationUserId == user.Id || prdso.StudentsCouncil.ApplicationUserId == user.Id).FirstOrDefault();
            //    ViewBag.HasPrdso = prdsoobj != null ? "True" : "False";
            //}
            //else
            //{
            //    ViewBag.Status = "Not";
            //    ViewBag.HasPrdso = "False";
            //}
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
