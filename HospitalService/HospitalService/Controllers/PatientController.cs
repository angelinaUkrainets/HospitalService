using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers
{
    public class PatientController : Controller
    {
        private readonly EFContext _context;
        public PatientController(EFContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult YourProfile()
        {
            YourProfileViewModel model = new YourProfileViewModel()
            {
            
            };

            return View();
        }

        [HttpGet]
        public IActionResult ChangeData(YourProfileViewModel model)
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ChangeData(YourProfileViewModel model)
        //{
        //    return View();
        //}
    }
}