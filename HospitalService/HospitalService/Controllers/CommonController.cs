using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data.EFContext;
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

        public IActionResult News()
        {
            return View();
        }
    }
}