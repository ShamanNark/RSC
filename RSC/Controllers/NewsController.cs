using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RSC.Data;
using RSC.Models.NewsViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace RSC.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db;
        private IHostingEnvironment _appEnvironment; 

        public NewsController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexNewsViewModel
            {
                News = db.News.Select(n => new DetailsNewsViewModel
                {
                    Id = n.Id,
                    Text = n.Text,
                    Title = n.Title,
                    AdditionalImagePath = n.AdditionalImages,
                    MainImagePath = n.MainImage,
                    CreateDateTime = n.CreateDateTime
                }).OrderByDescending(n => n.CreateDateTime).ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateNewsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            var maxId = db.News.Max(n => n.Id) + 1;
            db.News.Add(new ObjectNews
            {
                Id = model.Id,
                MainImage = await SaveFile(model.MainImage, maxId.ToString()),
                Text = model.Text,
                Title = model.Title,
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewmodel = db.News.Where(n => n.Id == id).Select(n => new EditNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                MainImagePath = n.MainImage,
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditNewsViewModel model)
        {
            var news = db.News.Where(n => n.Id == model.Id).FirstOrDefault();
            news.Title = model.Title;
            news.Text = model.Text;
            news.MainImage = await SaveFile(model.MainImage, news.Id.ToString()) ?? news.MainImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewmodel = db.News.Where(n => n.Id == id).Select(n => new DetailsNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                MainImagePath = n.MainImage
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viewmodel = db.News.Where(n => n.Id == id).Select(n => new DetailsNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                MainImagePath = n.MainImage
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Delete(DetailsNewsViewModel model)
        {
            var dbModel = db.News.Where(n => n.Id == model.Id).FirstOrDefault();
            db.News.Remove(dbModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private async Task<string> SaveFile(IFormFile uploadedFile, string FileName)
        {
            if (uploadedFile != null && (uploadedFile.ContentType == "image/png" || uploadedFile.ContentType == "image/jpeg"))
            {
                string contentType = uploadedFile.ContentType == "image/png" ? ".png" : ".jpg"; 
                string path = "/images/" + FileName + contentType;
                // сохраняем файл в папку images в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                return path;
            }
            else
            {
                return null;
            }
        }
    }
}