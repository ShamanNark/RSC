﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RSC.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OurTeam()
        {
            return View();
        }

        public IActionResult EkspertniySovet()
        {
            return View();
        }
        public IActionResult Otdeli()
        {
            return View();
        }
        public IActionResult Rukovodstvo()
        {
            return View();
        }

        public IActionResult Rosstudenchestvo()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult AboutPrdso()
        {
            return View();
        }

        public IActionResult Napravleniya()
        {
            return View();
        }


    }
}