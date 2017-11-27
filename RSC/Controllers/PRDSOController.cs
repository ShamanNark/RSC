using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RSC.Data;
using RSC.Models;
using RSC.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSC.Controllers.Models.PRDSOViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace RSC.Controllers
{
    public class PRDSOController : Controller
    {
        private readonly ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;

        public PRDSOController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<University, UniversityViewModel>();
                cfg.CreateMap<StudentsCouncil, StudentsCouncilViewModel>();
                cfg.CreateMap<CreatePRDSOViewModel, Prdso>();
                cfg.CreateMap<StudentsCouncilViewModel, StudentsCouncil>();
            });
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var oovo = db.Universities.Include(university => university.ApplicationUser)
                                      .Include(university => university.UniversityData)
                                      .Where(university => university.ApplicationUserId == user.Id).FirstOrDefault();
            if (oovo == null && oovo.ApplicationUser.Status == ApplicationUserStatus.Approved)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new CreatePRDSOViewModel
            {
                UniversityViewModel = Mapper.Map<University, UniversityViewModel>(oovo),
                Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name"),
                UniversityDatas = new SelectList(db.UniversityDatas.Select(uny => new { Id = uny.Id, Name = uny.UniversityName }), "Id", "Name"),
                StudentCouncils = Mapper.Map<List<StudentsCouncilViewModel>>(db.StudentsCouncils.Where(sc => sc.EducationalOrganizationId == oovo.UniversityDataId).ToList()),
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(CreatePRDSOViewModel model)
        {
            if (ModelState.IsValid)
            {
                var prdso = Mapper.Map<Prdso>(model);
                var dbUviversity = db.Universities.Where(university => university.Id == model.UniversityViewModel.Id).FirstOrDefault();
                if (dbUviversity != null)
                {
                    dbUviversity.Name = model.UniversityViewModel.Name;
                    dbUviversity.MiddleName = model.UniversityViewModel.MiddleName;
                    dbUviversity.Surname = model.UniversityViewModel.Surname;
                    dbUviversity.JobPhoneNumber = model.UniversityViewModel.JobPhoneNumber;
                    dbUviversity.Fax = model.UniversityViewModel.Fax;
                    db.Universities.Update(dbUviversity);
                    prdso.UniversityId = dbUviversity.Id;
                }

                if (model.CreateStudentCouncil)
                {
                    var dbCouncil = Mapper.Map<Data.DbModels.StudentsCouncil>(model.StudentsCouncilViewModel);
                    dbCouncil.RegionId = dbUviversity.RegionId;
                    dbCouncil.EducationalOrganizationId = dbUviversity.UniversityDataId;
                    db.StudentsCouncils.Add(dbCouncil);
                    prdso.StudentsCouncilId = dbCouncil.Id;
                }
                db.PrdsoList.Add(prdso);
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
            return View(model);
        }
    }
}