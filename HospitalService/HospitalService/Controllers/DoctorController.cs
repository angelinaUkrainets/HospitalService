using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.Interfaces;
using HospitalService.Data.Models;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctors _doctors;
        public DoctorController(IDoctors doctors)
        {
            _doctors = doctors;
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
            }
            return View();
        }
    }
}