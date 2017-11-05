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
using RSC.Models.NewsRubricsViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSC.Data.DbModels;
using RSC.Models;

namespace RSC.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db;
        private IHostingEnvironment _appEnvironment;
        int pageSize = 10;

        public NewsController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index(int page = 1)
        {
            var count = db.News.Count();
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
                }).OrderByDescending(n => n.CreateDateTime).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageViewModel = new PageViewModel(count, page, pageSize)
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var NewsRubricsViewModel = db.NewsRubrics.Select(n => new NewsRubricViewModel
            {
                Id = n.Id,
                Name = n.Name
            }).ToList();
            var rubrics = new SelectList(NewsRubricsViewModel, "Id", "Name");
            return View(new CreateNewsViewModel() { NewsRubrics = rubrics });
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
                ListObjectNewsNewsRubric = model.SelectedRubrics.Any() ? model.SelectedRubrics.Select(rubric => new Data.DbModels.ObjectNewsNewsRubric
                {
                    NewsRubricId = rubric
                }).ToList() : new List<ObjectNewsNewsRubric>(),
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var NewsRubricsViewModel = db.NewsRubrics.Select(n => new NewsRubricViewModel
            {
                Id = n.Id,
                Name = n.Name
            }).ToList();
            var viewmodel = db.News.Where(n => n.Id == id).Select(n => new EditNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                MainImagePath = n.MainImage,
                CreateDateTime = n.CreateDateTime,
                SelectedRubrics = n.ListObjectNewsNewsRubric.Select(l => l.NewsRubricId).ToList(),
                NewsRubrics = new SelectList(NewsRubricsViewModel, "Id", "Name", n.ListObjectNewsNewsRubric.Select(l => l.NewsRubricId).ToList())
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditNewsViewModel model)
        {
            var news = db.News.Include(n => n.ListObjectNewsNewsRubric).FirstOrDefault(n => n.Id == model.Id);
            var rubricids = news.ListObjectNewsNewsRubric.ToList();
            if (rubricids.Any())
            {
                var rubricsForDeleting = rubricids.Where(rubricId => model.SelectedRubrics.All(selectedRubricId => selectedRubricId != rubricId.NewsRubricId)).ToList();
                var rubricForAdding = model.SelectedRubrics.Where(selectedRubricId => rubricids.All(rubric => rubric.NewsRubricId != selectedRubricId)).ToList();
                db.ListObjectNewsNewsRubric.RemoveRange(rubricsForDeleting);
                db.ListObjectNewsNewsRubric.AddRange(rubricForAdding.Select(rubric => new ObjectNewsNewsRubric
                {
                    NewsRubricId = rubric,
                    ObjectNewsId = news.Id
                }).ToList());
            }

            news.Title = model.Title;
            news.Text = model.Text;
            news.CreateDateTime = model.CreateDateTime;
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


        [HttpGet]
        public IActionResult TakeLastSix (string newsRubricm, int? pagenum)
        {
            int pageNumber = (pagenum ?? 1);       
            var viewModel = new IndexNewsViewModel
            {
                News = db.ListObjectNewsNewsRubric.Where(l => l.NewsRubricId == 1).Select(n => new DetailsNewsViewModel
                {
                    Id = n.ObjectNews.Id,
                    Text = n.ObjectNews.Text,
                    Title = n.ObjectNews.Title,
                    AdditionalImagePath = n.ObjectNews.AdditionalImages,
                    MainImagePath = n.ObjectNews.MainImage,
                    CreateDateTime = n.ObjectNews.CreateDateTime
                }).OrderByDescending(n => n.CreateDateTime).Take(pageSize).ToList(),
                NewsRubrics = db.NewsRubrics.Select(n => new Models.NewsRubricsViewModels.NewsRubricViewModel
                {
                    Id = n.Id,
                    Name = n.Name
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetNewsByRubricId (int id, DateTime startDateTime, DateTime stopDateTime)
        {
            var model = db.ListObjectNewsNewsRubric.Where(l => l.NewsRubricId == id).Where(l => l.ObjectNews.CreateDateTime >= startDateTime && l.ObjectNews.CreateDateTime <= stopDateTime).Select(n => new DetailsNewsViewModel
            {
                Id = n.ObjectNews.Id,
                Text = n.ObjectNews.Text,
                Title = n.ObjectNews.Title,
                AdditionalImagePath = n.ObjectNews.AdditionalImages,
                MainImagePath = n.ObjectNews.MainImage,
                CreateDateTime = n.ObjectNews.CreateDateTime
            }).OrderByDescending(n => n.CreateDateTime).Take(pageSize).ToList();
            return PartialView("PartialViewNews", model);
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