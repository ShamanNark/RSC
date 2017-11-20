using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Controllers.Models.PRDSOViewModels;

namespace RSC.Controllers
{
    public class PRDSOController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePRDSOViewModel model)
        {
            return View();
        }
    }
}