using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using HospitalService.Models;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

                var user = _context.Users.FirstOrDefault(u => u.Id == result.Id);

                YourProfileViewModel model = new YourProfileViewModel()
                {
                   //Login = user.
                };
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