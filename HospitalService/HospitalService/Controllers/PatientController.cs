using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using HospitalService.Models;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            var info = HttpContext.Session.GetString("UserInfo");
            if (info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);

                var user = _context.PatientProfiles.FirstOrDefault(x => x.Id == result.Id);
                
                YourProfileViewModel model = new YourProfileViewModel()
                {
                    Login = user.Login,
                    DateBirth = user.DateOfBirth.ToString("dd/MM/yyyy"),
                    Email = result.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ImagePath = user.Image,
                    TypeBlood = user?.TypeBlood
                };
                return View(model);
            }

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