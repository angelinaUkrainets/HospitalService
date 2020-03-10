using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using HospitalService.Models;
using HospitalService.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HospitalService.Controllers
{
    public class PatientController : Controller
    {
        private readonly EFContext _context;
        private readonly IHostingEnvironment _env;
        public PatientController(EFContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
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
        public IActionResult ChangeData()
        {
            var info = HttpContext.Session.GetString("UserInfo");

            if(info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
                var user = _context.PatientProfiles.FirstOrDefault(x => x.Id == result.Id);

                YourProfileViewModel model = new YourProfileViewModel()
                {
                    Email = result.Email,
                    Login = user.Login,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    DateBirth = user.DateOfBirth.ToString("dd/MM/yyyy"),
                    TypeBlood = user.TypeBlood,
                    ImagePath = user.Image
                };
                return View(model);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeData(YourProfileViewModel model)
        {
            var info = HttpContext.Session.GetString("UserInfo");
            if (info == null)
                return View();
            if (ModelState.IsValid)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
                var user = _context.PatientProfiles.FirstOrDefault(u => u.Id == result.Id);
                user.FirstName = model.FirstName;
                user.DateOfBirth = Convert.ToDateTime(model.DateBirth);
                user.Image = model.ImagePath;
                user.LastName = model.LastName;
                user.Login = model.Login;
                user.TypeBlood = model.TypeBlood;
                user.User.Email = model.Email;
                if(user.Image == null)
                {
                    user.Image = "https://rtfm.co.ua/wp-content/plugins/all-in-one-seo-pack/images/default-user-image.png";
                }
                _context.PatientProfiles.Add(user);
                _context.SaveChanges();
                return RedirectToAction("YourProfile");
            }
            return View();
        }
    }
}