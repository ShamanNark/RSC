using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Data.DbModels;
using RSC.Models.NewsRubricsViewModels;

namespace RSC.Controllers
{
    public class NewsRubricsController : Controller
    {
        private ApplicationDbContext db;

        public NewsRubricsController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var IndexModel = db.NewsRubrics.Select(rubric => new NewsRubricViewModel
            {
                Id = rubric.Id,
                Name = rubric.Name
            }).ToList();
            return View(IndexModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new NewsRubricViewModel());
        }

        [HttpPost]
        public IActionResult Create(NewsRubricViewModel model)
        {
            db.NewsRubrics.Add(new NewsRubric
            {
                Name = model.Name
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = db.NewsRubrics.Where(rubric => rubric.Id == id).Select(rubric => new NewsRubricViewModel
            {
                Id = rubric.Id,
                Name = rubric.Name
            }).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(NewsRubricViewModel model)
        {
            var dbModel = db.NewsRubrics.Where(rubric => rubric.Id == model.Id).FirstOrDefault();
            if(dbModel != null && !string.IsNullOrEmpty(model.Name))
            {
                dbModel.Name = model.Name;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = db.NewsRubrics.Where(rubric => rubric.Id == id).Select(rubric => new NewsRubricViewModel
            {
                Id = rubric.Id,
                Name = rubric.Name
            }).FirstOrDefault();
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(NewsRubricViewModel model)
        {
            var dbModel = db.NewsRubrics.Where(rubric => rubric.Id == model.Id).FirstOrDefault();
            if (dbModel != null)
            {
                db.NewsRubrics.Remove(dbModel);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}