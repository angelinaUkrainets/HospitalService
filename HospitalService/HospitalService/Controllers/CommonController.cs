using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers
{
    public class CommonController : Controller
    {
        private readonly EFContext _context;

        public CommonController(EFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Patient")]
        [Authorize(Roles = "Doctor")]
        [Authorize(Roles = "Admin")]
        public IActionResult News()
        {
            return View();
        }
    }
}