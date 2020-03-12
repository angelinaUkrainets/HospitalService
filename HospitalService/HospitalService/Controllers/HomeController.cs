using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalService.Models;
using HospitalService.ViewModels;
using HospitalService.Data.EFContext;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using HospitalService.Data.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HospitalService.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly RoleManager<DbRole> _roleManager;
        private readonly EFContext _context;
        private readonly IHostingEnvironment _env;


        public HomeController(UserManager<DbUser> userManager, SignInManager<DbUser> signInManager,
            RoleManager<DbRole> roleManager, EFContext context, IHostingEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _env = env;
        }
        [Authorize(Roles ="User")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                var roleName = "Patient";
                //if (uploadedFile == null && uploadedFile.Length > 0)
                //    return RedirectToAction("Register");

                //var folderServerPath = _env.ContentRootPath;
                //var folderName = "Uploaded";
                //var fileName = Guid.NewGuid().ToString() + ".jpg";
                //var savefile = Path.Combine(folderServerPath, folderName, fileName);
                //using (var stream = System.IO.File.Create(savefile))
                //{
                //    await uploadedFile.CopyToAsync(stream);
                //}

                if (model.ImageName == null)
                {
                    model.ImageName = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR_q1QWy4q604M8nPCoHqq1rR8OCoQ3wx5iRScLfgjO7F1-gwdH";
                }

                PatientProfile patient = new PatientProfile()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Login = model.Login,
                    Image = model.ImageName,
                    DateOfBirth = Convert.ToDateTime(model.TimeOfBirth),
                    Sicknesses = null,
                    VisitRequests = null
                };

                var dbUser = new DbUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PatientProfiles = patient
                };

                var result = await _userManager.CreateAsync(dbUser, model.Password);
                result = _userManager.AddToRoleAsync(dbUser, roleName).Result;

                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(dbUser, false);
                    return RedirectToAction("Login", "Home");
                }
                else 
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if(user == null)
            {
                ModelState.AddModelError("", "Don`t correct login");
                return View(model);
            }

            var result = _signInManager
                .PasswordSignInAsync(user, model.Password, false, false).Result;

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Don`t correct password");
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            await Authenticate(model.Email);
            var obj = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            string role = obj.Role.Name; 

            var userInfo = new UserInfo()
            {
                Id = user.Id,
                Email = user.Email
            };
            HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(userInfo));

            if (role == "Doctor")
                return RedirectToAction("DoctorNews", "Doctor");
            else
                return RedirectToAction("News", "Common");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }


    }
}
