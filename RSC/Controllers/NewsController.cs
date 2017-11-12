using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Models.NewsViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using RSC.Models.NewsRubricsViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSC.Data.DbModels;
using RSC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using System.Drawing;

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

        [Authorize(Roles = "admin")]
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
                    HomePageImagePath = n.HomePageImage,
                    MainImagePath = n.MainImage,
                    CreateDateTime = n.CreateDateTime
                }).OrderByDescending(n => n.CreateDateTime).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageViewModel = new PageViewModel(count, page, pageSize)
            };
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            var maxId = db.News.Max(n => n.Id) + 1;
            var dbmodel = db.News.Add(new ObjectNews
            {
                Id = model.Id,
                MainImage = await SaveFile(model.MainImage, maxId.ToString()),
                HomePageImage = SaveImageFromBase64String(model.HomePageImage, maxId.ToString()),
                Text = model.Text,
                Title = model.Title,
                ListObjectNewsNewsRubric = model.SelectedRubrics != null ? model.SelectedRubrics.Select(rubric => new Data.DbModels.ObjectNewsNewsRubric
                {
                    NewsRubricId = rubric
                }).ToList() : new List<ObjectNewsNewsRubric> { new ObjectNewsNewsRubric { NewsRubricId = 1 } },
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now
            });            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
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
                HomePageImagePath = n.HomePageImage,
                CreateDateTime = n.CreateDateTime,
                SelectedRubrics = n.ListObjectNewsNewsRubric.Select(l => l.NewsRubricId).ToList(),
                NewsRubrics = new SelectList(NewsRubricsViewModel, "Id", "Name", n.ListObjectNewsNewsRubric.Select(l => l.NewsRubricId).ToList())
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(EditNewsViewModel model)
        {
            var news = db.News.Include(n => n.ListObjectNewsNewsRubric).FirstOrDefault(n => n.Id == model.Id);
            var rubricids = news.ListObjectNewsNewsRubric.ToList();
            if (rubricids.Any() && model.SelectedRubrics != null)
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
            if (model.MainImage != null)
            {
                news.MainImage = await SaveFile(model.MainImage, news.Id.ToString()) ?? news.MainImage;
            }

            if (string.IsNullOrEmpty(model.HomePageImage))
            {
                news.HomePageImage = SaveImageFromBase64String(model.HomePageImage, news.Id.ToString());
            }

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
                MainImagePath = n.MainImage,
                HomePageImagePath = n.HomePageImage,
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var viewmodel = db.News.Where(n => n.Id == id).Select(n => new DetailsNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                MainImagePath = n.MainImage,
                HomePageImagePath = n.HomePageImage,
            }).FirstOrDefault();
            return View(viewmodel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(DetailsNewsViewModel model)
        {
            var dbModel = db.News.Where(n => n.Id == model.Id).FirstOrDefault();
            db.News.Remove(dbModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult NewsBoard(int newsRubricId = 1, int page = 1)
        {
            var dbQuery = db.ListObjectNewsNewsRubric.Where(l => l.NewsRubricId == newsRubricId).AsQueryable();
            var count = dbQuery.Count();
            var viewModel = new IndexNewsViewModel
            {
                News = dbQuery.Select(n => new DetailsNewsViewModel
                {
                    Id = n.ObjectNews.Id,
                    Text = n.ObjectNews.Text,
                    Title = n.ObjectNews.Title,
                    HomePageImagePath = n.ObjectNews.HomePageImage,
                    MainImagePath = n.ObjectNews.MainImage,
                    CreateDateTime = n.ObjectNews.CreateDateTime
                }).OrderByDescending(n => n.CreateDateTime).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                NewsRubrics = db.NewsRubrics.Select(n => new Models.NewsRubricsViewModels.NewsRubricViewModel
                {
                    Id = n.Id,
                    Name = n.Name
                }).ToList(),
                PageViewModel = new PageViewModel(count, page, pageSize)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetNewsByRubricId (int id, DateTime startDateTime, DateTime stopDateTime, int page = 1)
        {
            var dbQuery = db.ListObjectNewsNewsRubric.Where(l => l.NewsRubricId == id)
                .Where(l => l.ObjectNews.CreateDateTime >= startDateTime && l.ObjectNews.CreateDateTime <= stopDateTime)
                .AsQueryable();
            var count = dbQuery.Count();
            var viewModel = new IndexNewsViewModel
            {
                News = dbQuery.Select(n => new DetailsNewsViewModel
                {
                    Id = n.ObjectNews.Id,
                    Text = n.ObjectNews.Text,
                    Title = n.ObjectNews.Title,
                    HomePageImagePath = n.ObjectNews.HomePageImage,
                    MainImagePath = n.ObjectNews.MainImage,
                    CreateDateTime = n.ObjectNews.CreateDateTime
                }).OrderByDescending(n => n.CreateDateTime).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageViewModel = new PageViewModel(count, page, pageSize)
            };
            return PartialView("PartialViewNews", viewModel);
        }

        private async Task<string> SaveFile(IFormFile uploadedFile, string FileName)
        {
            if (uploadedFile != null && (uploadedFile.ContentType == "image/png" || uploadedFile.ContentType == "image/jpeg"))
            {
                string contentType = uploadedFile.ContentType == "image/png" ? ".png" : ".jpg"; 
                string path = "/images/" + FileName + contentType;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                return path;
            }
            else
            {
                return String.Empty;
            }
        }

        private string SaveImageFromBase64String (string base64String, string imageName)
        {
            if (!string.IsNullOrEmpty(base64String))
            {
                string[] words = base64String.Split(new char[] { ';', ',' });
                byte[] byteBuffer = Convert.FromBase64String(words[2]);
                string path = $"/images/HomePageImages/{imageName}.png";
                System.IO.File.WriteAllBytes(_appEnvironment.WebRootPath + path, byteBuffer);
                return path;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}