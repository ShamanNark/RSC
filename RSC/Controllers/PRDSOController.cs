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
using RSC.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace RSC.Controllers
{
    public class PRDSOController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _appEnvironment;

        public PRDSOController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                               SignInManager<ApplicationUser> signInManager, IEmailSender emailSender,
                               ILogger<AccountController> logger, IHostingEnvironment appEnvironment)
        {
            db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _appEnvironment = appEnvironment;
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
            if (oovo == null || oovo.ApplicationUser.Status != ApplicationUserStatus.Approved)
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
        public async  Task<IActionResult> Create(CreatePRDSOViewModel model)
        {
            if (ModelState.IsValid)
            {

                var dowloadFiles = new Helper.DownloadFiles(db, _appEnvironment);
                var prdso = Mapper.Map<Prdso>(model);
                var dbUviversity = db.Universities.Include(university => university.UniversityData).Where(university => university.Id == model.UniversityViewModel.Id).FirstOrDefault();
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
                else
                {
                    model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
                    model.UniversityDatas = new SelectList(db.UniversityDatas.Select(uny => new { Id = uny.Id, Name = uny.UniversityName }), "Id", "Name");
                    return View(model);
                }

                if (model.CreateStudentCouncil)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.StudentsCouncilViewModel.Email,
                        Email = model.StudentsCouncilViewModel.Email
                    };
                    var result = await _userManager.CreateAsync(user, model.StudentsCouncilViewModel.Password);
                    if (result.Succeeded)
                    {
                        user.UserType = ApplicationUserTypes.StudentCouncil;
                        _logger.LogInformation("User created a new account with password.");
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                        await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created a new account with password.");
                    }
                    else
                    {
                        model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
                        model.UniversityDatas = new SelectList(db.UniversityDatas.Select(uny => new { Id = uny.Id, Name = uny.UniversityName }), "Id", "Name");
                        return View(model);
                    }

                    var dbCouncil = Mapper.Map<Data.DbModels.StudentsCouncil>(model.StudentsCouncilViewModel);
                    var orderCreationCouncilOfLearnersId = await dowloadFiles.AddFile
                        (model.StudentsCouncilViewModel.OrderCreationCouncilOfLearnersFile,
                        "/Приказ о создании Совета обучающихся/" + dbUviversity.UniversityData.UniversityShortName,
                        model.StudentsCouncilViewModel.OrderCreationCouncilOfLearnersFile.FileName);
                    if (orderCreationCouncilOfLearnersId != null)
                    {
                        dbCouncil.OrderCreationCouncilOfLearnersId = orderCreationCouncilOfLearnersId ?? 0;
                    }

                    var protocolApprovalStudentAssociationsId = await dowloadFiles.AddFile
                        (model.StudentsCouncilViewModel.ProtocolApprovalStudentAssociationsFile,
                        "/Протокол СО об утверждении/" + dbUviversity.UniversityData.UniversityShortName,
                        model.StudentsCouncilViewModel.ProtocolApprovalStudentAssociationsFile.FileName);
                    if (protocolApprovalStudentAssociationsId != null)
                    {
                        dbCouncil.ProtocolApprovalStudentAssociationsId = protocolApprovalStudentAssociationsId ?? 0;
                    }

                    var conferenceProtocolId = await dowloadFiles.AddFile
                        (model.StudentsCouncilViewModel.ConferenceProtocolFile,
                        "/Протокол отчетно-выборной конференции СО/" + dbUviversity.UniversityData.UniversityShortName,
                        model.StudentsCouncilViewModel.ConferenceProtocolFile.FileName);
                    if (conferenceProtocolId != null)
                    {
                        dbCouncil.ConferenceProtocolId = conferenceProtocolId ?? 0;
                    }
                    dbCouncil.ApplicationUserId = user.Id;
                    dbCouncil.RegionId = dbUviversity.RegionId;
                    dbCouncil.EducationalOrganizationId = dbUviversity.UniversityDataId;
                    db.StudentsCouncils.Add(dbCouncil);
                    db.SaveChanges();
                    prdso.StudentsCouncilId = dbCouncil.Id;
                }
                var fileid = await dowloadFiles.AddFile(model.EGRULfile, "/EGRUL/" + dbUviversity.UniversityData.UniversityShortName, model.EGRULfile.FileName);
                if(fileid != null)
                {
                    prdso.EGRULId = fileid ?? 0;
                }

                var oderApprovalRectorId = await dowloadFiles.AddFile(model.OderApprovalRectorFile, "/Приказ об утверждении (назначении) ректора/" + dbUviversity.UniversityData.UniversityShortName, model.OderApprovalRectorFile.FileName);
                if (fileid != null)
                {
                    prdso.OderApprovalRectorId = oderApprovalRectorId ?? 0;
                }

                db.PrdsoList.Add(prdso);
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }

            model.Regions = new SelectList(db.Regions.Select(region => new { Id = region.Id, Name = region.RegionName }).ToList(), "Id", "Name");
            model.UniversityDatas = new SelectList(db.UniversityDatas.Select(uny => new { Id = uny.Id, Name = uny.UniversityName }), "Id", "Name");
            model.StudentCouncils = Mapper.Map<List<StudentsCouncilViewModel>>(db.StudentsCouncils.Where(sc => sc.EducationalOrganizationId == model.UniversityViewModel.UniversityDataId).ToList());
            return View(model);
        }
    }
}