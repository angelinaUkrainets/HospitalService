using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using HospitalService.Data.Interfaces;
using HospitalService.Data.Models;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctors _doctors;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        public DoctorController(IDoctors doctors, UserManager<DbUser> userManager,
            SignInManager<DbUser> signInManager)
        {
            _doctors = doctors;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Doctor/GetDoctors")]
        [Route("Doctor/GetDoctors/{specialization}")]
        public IActionResult GetDoctors(string specialization)
        {
            IEnumerable<DoctorProfile> doctors = null;
            string doctorSpecialization = "";
            if (string.IsNullOrEmpty(specialization))
            {
                doctors = _doctors.GetDoctors.OrderBy(i => i.Id);
            }
            else
            {
                doctors = _doctors.GetDoctors.Where(x => x.Specializations.Type.ToLower() == specialization.ToLower());

                doctorSpecialization = specialization;
            }
            var doctorObj = new DoctorListViewModel
            {
                GetDoctors = doctors,
                DoctorSpecialization = specialization
            };

            ViewBag.Title = "All Doctors";
            return View(doctorObj);

        }

        [HttpGet]
        public IActionResult DoctorRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoctorRegister(RegisterDoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleName = "Doctor";
                if (model.ImageName == null)
                {
                    model.ImageName = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR_q1QWy4q604M8nPCoHqq1rR8OCoQ3wx5iRScLfgjO7F1-gwdH";
                }
                DoctorProfile doctor = new DoctorProfile()
                {
                    Login = model.Login,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Experience = model.Experience,
                    SpecializationId = Convert.ToInt32(model.SicknessId),
                    HospitalId = 1,
                    Image = model.ImageName
                };
                var dbUser = new DbUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    DoctorProfiles = doctor
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
    }
}