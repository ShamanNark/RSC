using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSC.Data;
using RSC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using RSC.Controllers.Models.AccountViewModels;
using Microsoft.EntityFrameworkCore;

namespace RSC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;
        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
            Mapper.Initialize(cfg => {
                        cfg.CreateMap<ApplicationUser, ConfirmationUsersViewModel>();
                        cfg.CreateMap<Data.DbModels.Student, AdditionInfo>();
                        cfg.CreateMap<Data.DbModels.StudentsCouncil, AdditionInfo>();
                        cfg.CreateMap<Data.DbModels.University, AdditionInfo>();
                        cfg.CreateMap<Data.DbModels.Assessor, AdditionInfo>();
                    });
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult СonfirmationUsers()
        {
            var model = new List<ConfirmationUsersViewModel>();
            var users = _userManager.Users.ToList();
            foreach(var user in users)
            {
                var item = TypingUser(user);
                model.Add(item);                
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditStatusUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            ViewBag.Statuses = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = true, Text = "Ожидание", Value = "0"},
                new SelectListItem { Selected = false, Text = "Потверждено", Value = "1"},
                new SelectListItem { Selected = false, Text = "Отказано", Value = "2"},
            }, "Value", "Text", 0);
            return View(TypingUser(user));
        }

        [HttpPost]
        public async Task<IActionResult> EditStatusUser(ApplicationUser user)
        {
            var userdb = await _userManager.FindByIdAsync(user.Id);
            userdb.Status = user.Status;
            await db.SaveChangesAsync();
            return RedirectToAction("СonfirmationUsers", "Admin");
        }

        private ConfirmationUsersViewModel TypingUser(ApplicationUser user)
        {
            var item = Mapper.Map<ApplicationUser, ConfirmationUsersViewModel> (user);
            switch (user.UserType)
            {
                case ApplicationUserTypes.Student:
                    var studentdb = db.Students.Where(student => student.ApplicationUserId == user.Id).FirstOrDefault();
                    item.AdditionInfoType = "Student";
                    item.AdditionInfo = Mapper.Map<AdditionInfo>(studentdb);
                    break;
                case ApplicationUserTypes.Assessor:
                    var assessordb = db.Asssessors.Where(assessor => assessor.ApplicationUserId == user.Id).FirstOrDefault();
                    item.AdditionInfoType = "Assessor";
                    item.AdditionInfo = Mapper.Map<AdditionInfo>(assessordb);
                    break;
                case ApplicationUserTypes.StudentCouncil:
                    var councildb = db.StudentsCouncils.Include(council => council.Region)
                                                       .Include(council => council.UniversityData)
                                                       .Include(council => council.ConferenceProtocol)
                                                       .Include(council => council.OrderCreationCouncilOfLearners)
                                                       .Include(council => council.ProtocolApprovalStudentAssociations)
                                                       .Where(council => council.ApplicationUserId == user.Id).FirstOrDefault();
                    item.AdditionInfoType = "StudentCouncil";
                    item.AdditionInfo = Mapper.Map<AdditionInfo>(councildb);
                    break;
                case ApplicationUserTypes.University:
                    var universitydb = db.Universities.Include(council => council.Region)
                                                       .Include(council => council.UniversityData)
                                                       .Include(council => council.PowerOfAttorney)
                                                       .Where(university => university.ApplicationUserId == user.Id).FirstOrDefault();
                    item.AdditionInfoType = "University";
                    item.AdditionInfo = Mapper.Map<AdditionInfo>(universitydb);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return item;
        }
    }
}