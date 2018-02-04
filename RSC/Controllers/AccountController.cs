using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RSC.Models;
using RSC.Models.AccountViewModels;
using RSC.Services;
using RSC.Models.RegisterViewModels;
using RSC.Data;
using RSC.Data.DbModels;
using AutoMapper;
using RSC.Controllers.Models.AccountViewModels;
using Microsoft.AspNetCore.Hosting;
using RSC.Helper;
using System.Security.Cryptography;

namespace RSC.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        IHostingEnvironment _appEnvironment;
        private readonly ApplicationDbContext db;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IHostingEnvironment appEnvironment,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _appEnvironment = appEnvironment;
            db = context;
            Mapper.Initialize(cfg => { cfg.CreateMap<RegisterAssessorViewModel, Assessor>();
                                       cfg.CreateMap<RegisterStudentViewModel, Student>();
                                       cfg.CreateMap<RegisterStudentCouncilViewModel, StudentsCouncil>();
                                       cfg.CreateMap<RegisterUniversityViewModel, University>();
                                       cfg.CreateMap<RSC.Controllers.Models.ApplicationUserViewModel, ApplicationUser>();
                                     });
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string statusmessage)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewBag.StatusMessage = statusmessage;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                //_signInManager.SignInAsync()
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var model = new LoginWith2faViewModel { RememberMe = rememberMe };
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignedOut()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            ViewBag.Regions = new SelectList(db.Regions.Select(b => new { Id = b.Id, Name = b.RegionName }).ToList(), "Id", "Name");          
            ViewBag.Degress = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = true, Text = "Магистр", Value = "0"},
                new SelectListItem { Selected = false, Text = "Среднее образование", Value = "1"},
                new SelectListItem { Selected = false, Text = "Общее образование", Value = "2"},
            }, "Value", "Text", 0);
            ViewBag.UniversityDatas = db.UniversityDatas.Select(u => new UniversityDatasViewModel
            {
                Id = u.Id,
                Name = u.UniversityName,
                ShortName = u.UniversityShortName
            }).ToList();
            ViewBag.ErrorMessage = model.StatusMessage;

            return View();
        }

        /*[HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }*/

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterStudent()
        {
            //ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent(RegisterStudentViewModel model, string returnUrl = null)
        {           
            if (ModelState.IsValid)
            {
                var isEmailExist = db.Users.Any(u => u.Email == model.ApplicationUserViewModel.Email);
                if (isEmailExist)
                {
                    return new RedirectToActionResult("Register", "Account", new RegisterViewModel { StatusMessage = "Ошибка: такой email уже существует" });
                }

                Helper.DownloadFiles saveFileHelper = new DownloadFiles(db, _appEnvironment);
                var imageId = await saveFileHelper.SaveProfileImage(model.ApplicationUserViewModel.AvatarFile, model.ApplicationUserViewModel.AvatarFile.FileName, model.ApplicationUserViewModel.AvatarFile.Name);
                var user = new Student
                {
                    UniversityDataId = model.UniversityDataId,
                    CategoryId = model.CategoryId,
                    ApplicationUser = Mapper.Map<ApplicationUser>(model.ApplicationUserViewModel)
                };
                //user.ApplicationUser.PasswordHash = _userManager.PasswordHasher.HashPassword(user.ApplicationUser.Email, model.ApplicationUserViewModel.Password);
                user.ApplicationUser.AvatarId = imageId;
                user.ApplicationUser.LockoutEnabled = true;
                user.ApplicationUser.UserName = user.ApplicationUser.Email;
                user.ApplicationUser.NormalizedEmail = user.ApplicationUser.Email.ToUpper();
                user.ApplicationUser.NormalizedUserName = user.ApplicationUser.Email.ToUpper();
                await db.Students.AddAsync(user);
                await db.SaveChangesAsync();
                await _userManager.AddPasswordAsync(user.ApplicationUser, model.ApplicationUserViewModel.Password);
                return RedirectToAction("Login", "Account",  new { statusmessage = "Регистрация прошла успешно"});
            }

            return RedirectToAction("Register", "Account" , "Ошибка: заполните все обязательные поля");
        }
        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterAssessor()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAssessor(RegisterAssessorViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                Helper.DownloadFiles saveFileHelper = new DownloadFiles(db, _appEnvironment);
                var avatarid = await saveFileHelper.SaveProfileImage(model.ApplicationUserViewModel.AvatarFile, model.ApplicationUserViewModel.AvatarFile.Name, model.ApplicationUserViewModel.AvatarFile.FileName);
                var user = new Assessor
                {                
                    ExperienceOfParticipation = model.ExperienceOfParticipation,
                    JobPhoneNumber = model.JobPhoneNumber,
                    Organisation = model.Organisation,
                    OrganisationPosition = model.OrganisationPosition,
                    ApplicationUser = Mapper.Map<ApplicationUser>(model.ApplicationUserViewModel)
                };
                user.ApplicationUser.AvatarId = avatarid;
                await db.Asssessors.AddAsync(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterStudentCouncil()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudentCouncil(RegisterStudentCouncilViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                Helper.DownloadFiles saveFileHelper = new DownloadFiles(db, _appEnvironment);
                var avatarId = await saveFileHelper.SaveProfileImage(model.ApplicationUserViewModel.AvatarFile, model.ApplicationUserViewModel.AvatarFile.Name, model.ApplicationUserViewModel.AvatarFile.FileName);

                if (model.ConferenceProtocolFile != null || model.OrderCreationCouncilOfLearnersFile != null || model.ProtocolApprovalStudentAssociationsFile != null)
                {
                    
                }

                var conferenceProtocolId = await saveFileHelper.SaveConferenceProtocol(model.ConferenceProtocolFile, model.ConferenceProtocolFile.Name, model.ConferenceProtocolFile.FileName);
                var orderCreationCouncilofLearnersId = await saveFileHelper.SaveOrderCreationCouncilOfLearners(model.OrderCreationCouncilOfLearnersFile, model.OrderCreationCouncilOfLearnersFile.Name, model.OrderCreationCouncilOfLearnersFile.FileName);
                var protocolApprovalStudentAssociationId = await saveFileHelper.SaveProtocolApprovalStudentAssociations(model.ProtocolApprovalStudentAssociationsFile, model.ProtocolApprovalStudentAssociationsFile.Name, model.ProtocolApprovalStudentAssociationsFile.FileName);
                

                var user = new StudentsCouncil
                {
                    UniversityDataId = model.UniversityDataId,
                    JobPhone = model.JobPhone,
                    Fax = model.Fax,
                    ConferenceProtocolId = conferenceProtocolId,
                    OrderCreationCouncilOfLearnersId = orderCreationCouncilofLearnersId,
                    ProtocolApprovalStudentAssociationsId = protocolApprovalStudentAssociationId,
                    ApplicationUser = Mapper.Map<ApplicationUser>(model.ApplicationUserViewModel)
                };
                user.ApplicationUser.AvatarId = avatarId;
                await db.StudentsCouncils.AddAsync(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterUniversity()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUniversity(RegisterUniversityViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var saveFilesHelper = new DownloadFiles(db, _appEnvironment);
                var avatarId = await saveFilesHelper.SaveProfileImage(model.ApplicationUserViewModel.AvatarFile, model.ApplicationUserViewModel.AvatarFile.Name, model.ApplicationUserViewModel.AvatarFile.FileName);
                var powerOfAttorneyFileId= await saveFilesHelper.SavePowerOfAttorney(model.PowerOfAttorneyFile, model.PowerOfAttorneyFile.Name, model.PowerOfAttorneyFile.FileName);
                var user = new University
                {
                    PowerOfAttorneyId = powerOfAttorneyFileId ?? 0,
                    UniversityWebSite = model.UniversityWebSite,
                    UniversityForm = model.UniversityForm,
                    UniversityDataId = model.UniversityDataId,
                    JobPhoneNumber = model.JobPhoneNumber,
                    Fax = model.Fax,                    
                    ApplicationUser = Mapper.Map<ApplicationUser>(model.ApplicationUserViewModel)
                };
                user.ApplicationUser.AvatarId = avatarId;
                await db.Universities.AddAsync(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            //return RedirectToAction(nameof(HomeController.Index), "Home");
            return RedirectToAction("Login","Account");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers
    
        private bool CheckEmailExist(string email)
        {
            return db.Users.Any(s => s.Email == email);            
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        private async Task RegisterFactory(object T)
        {
            switch (T.GetType().Name)
            {
                case "RegisterStudentViewModel":
                    await RegisterStudentDb(T as RegisterStudentViewModel);
                    break;
                case "RegisterStudentCouncilViewModel":
                    //await RegisterStudentCouncilDb(T as RegisterStudentCouncilViewModel);
                    break;
                case "RegisterUniversityViewModel":
                    //await RegisterUniversityDb(T as RegisterUniversityViewModel);
                    break;
                case "RegisterAssessorViewModel":
                    await RegisterAssessorDb(T as RegisterAssessorViewModel);
                    break;
                default:
                    break;
            }
        }

        private async Task RegisterAssessorDb(RegisterAssessorViewModel model)
        {
            var assessorDb = Mapper.Map<Assessor>(model);
            db.Asssessors.Add(assessorDb);
            await db.SaveChangesAsync();
            assessorDb.ApplicationUser.UserType = ApplicationUserTypes.Assessor;
            await _userManager.AddToRoleAsync(assessorDb.ApplicationUser, "ASSESSOR");
            await db.SaveChangesAsync();
        }

        //private async Task<bool> RegisterUniversityDb(RegisterUniversityViewModel model)
        //{
        //    var universityDb = Mapper.Map<University>(model);
        //    var downloadfile = new Helper.DownloadFiles(db, _appEnvironment);
        //    var nameFile = db.UniversityDatas.Where(u => u.Id == model.UniversityDataId).First();
        //    var powerofAttorneyId = await downloadfile.AddFile(model.PowerOfAttorneyFile, "/Доверенность/" + nameFile.UniversityShortName, model.PowerOfAttorneyFile.FileName);
        //    if(powerofAttorneyId != null)
        //    {
        //        universityDb.PowerOfAttorneyId = powerofAttorneyId ?? 0;
        //    }
        //    db.Universities.Add(universityDb);
        //    db.SaveChanges();
        //    universityDb.UniversityData.UniversityWebSite = model.UniversityWebSite;
        //    universityDb.ApplicationUser.UserType = ApplicationUserTypes.University;
        //    await _userManager.AddToRoleAsync(universityDb.ApplicationUser, "OOBO");
        //    db.SaveChanges();
        //    return true;
        //}

        //private async Task RegisterStudentCouncilDb(RegisterStudentCouncilViewModel model)
        //{
        //    var studentCouncilDb = Mapper.Map<StudentsCouncil>(model);
        //    var nameFile = db.UniversityDatas.Where(u => u.Id == model.UniversityDataId).First();
        //    var downloadFiles = new Helper.DownloadFiles(db, _appEnvironment);

        //    var orderCreationCouncilOfLearnersId = await downloadFiles.AddFile
        //        (model.OrderCreationCouncilOfLearnersFile,
        //        "/Приказ о создании Совета обучающихся/" + nameFile.UniversityShortName,
        //        model.OrderCreationCouncilOfLearnersFile.FileName);
        //    if (orderCreationCouncilOfLearnersId != null)
        //    {
        //        studentCouncilDb.OrderCreationCouncilOfLearnersId = orderCreationCouncilOfLearnersId ?? 0;
        //    }

        //    var protocolApprovalStudentAssociationsId = await downloadFiles.AddFile
        //        (model.ProtocolApprovalStudentAssociationsFile,
        //        "/Протокол СО об утверждении/" + nameFile.UniversityShortName,
        //        model.ProtocolApprovalStudentAssociationsFile.FileName);
        //    if (protocolApprovalStudentAssociationsId != null)
        //    {
        //        studentCouncilDb.ProtocolApprovalStudentAssociationsId = protocolApprovalStudentAssociationsId ?? 0;
        //    }

        //    var conferenceProtocolId = await downloadFiles.AddFile
        //        (model.ConferenceProtocolFile,
        //        "/Протокол отчетно-выборной конференции СО/" + nameFile.UniversityShortName,
        //        model.ConferenceProtocolFile.FileName);
        //    if (conferenceProtocolId != null)
        //    {
        //        studentCouncilDb.ConferenceProtocolId = conferenceProtocolId ?? 0;
        //    }

        //    db.StudentsCouncils.Add(studentCouncilDb);
        //    await db.SaveChangesAsync();
        //    studentCouncilDb.ApplicationUser.UserType = ApplicationUserTypes.StudentCouncil;
        //    await _userManager.AddToRoleAsync(studentCouncilDb.ApplicationUser, "CO");
        //    await db.SaveChangesAsync();
        //}

        private async Task RegisterStudentDb(RegisterStudentViewModel model)
        {
            var studentDb = Mapper.Map<Student>(model);
            db.Students.Add(studentDb);
            await db.SaveChangesAsync();
            studentDb.ApplicationUser.PhoneNumber = model.ApplicationUserViewModel.PhoneNumber;
            studentDb.ApplicationUser.UserType = ApplicationUserTypes.Student;
            await _userManager.AddToRoleAsync(studentDb.ApplicationUser, "STUDENT");
            await db.SaveChangesAsync();
        }

        private async Task<IActionResult> RegisterApplicationUser<T>(T model) where T: RegisterViewModel
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation("User created a new account with password.");
                model.ApplicationUserId = user.Id;
                await RegisterFactory(model);
                return RedirectToAction("Login", "Account");
            }

            AddErrors(result);

            ViewBag.Ganders = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = true, Text = "Мужской", Value = "0"},
                new SelectListItem { Selected = false, Text = "Женкский", Value = "1"},
            }, "Value", "Text", 0);
            ViewBag.Regions = new SelectList(db.Regions.Select(b => new { Id = b.Id, Name = b.RegionName }), "Id", "Name");

            ViewBag.Degress = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = true, Text = "Магистр", Value = "0"},
                new SelectListItem { Selected = false, Text = "Среднее образование", Value = "1"},
                new SelectListItem { Selected = false, Text = "Общее образование", Value = "2"},
            }, "Value", "Text", 0);
            ViewBag.UniversityDatas = db.UniversityDatas.Select(u => new UniversityDatasViewModel
            {
                Id = u.Id,
                Name = u.UniversityName,
                ShortName = u.UniversityShortName
            }).ToList();

            return View(model);
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return buffer3 == buffer4;
        }
        #endregion
    }
}
