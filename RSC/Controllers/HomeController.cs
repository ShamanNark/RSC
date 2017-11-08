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

namespace RSC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
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
