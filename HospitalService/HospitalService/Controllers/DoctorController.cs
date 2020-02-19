using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Doctor/GetDoctors")]
        [Route("Doctor/GetDoctors/{specialization}")]
        public IActionResult GetDoctors(string specialization)
        {
            return View();
        }
    }
}