using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using HospitalService.Service;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers
{
    public class CommonController : Controller
    {
        private readonly EFContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly RoleManager<DbRole> _roleManager;

        public CommonController(EFContext context, UserManager<DbUser> userManager,
            SignInManager<DbUser> signInManager, RoleManager<DbRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Patient, Doctor, Admin")]
        public IActionResult News()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "No corected email");
                return View(model);
            }

            var userName = user.Email;
            EmailService emailService = new EmailService();
            string url = "https://localhost:44306/Common/ChangePassword/" + user.Id;



            await emailService.SendEmailAsync(userName, "ForgotPassword",
                $" Dear {userName}," +
                $" <br/>" +
                $" To change your password" +
                $" <br/>" +
                $" you should visit this link <a href='{url}'>press</a>");
            return View(model);
        }

        [HttpGet]
        [Route("Common/ChangePassword/{id}")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("Common/ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    ModelState.AddModelError("", "This User not register");
                    return View(model);
                }



                var hash_password = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PasswordHash = hash_password;
                var result = await _userManager.UpdateAsync(user);

                
          
            }
            return RedirectToAction("Login", "Home");
        }
    }
}