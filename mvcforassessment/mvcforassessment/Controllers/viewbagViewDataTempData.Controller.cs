using Microsoft.AspNetCore.Mvc;
using mvcforassessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcforassessment.Controllers
{
    public class viewbagViewDataTempData : Controller
    {
        private readonly ApplicationDbContext _context;
        public viewbagViewDataTempData(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var emp = _context.Employee.ToList();
            ViewBag.name = emp;
            var dep = _context.Department.ToList();
            ViewData["dep1"] = dep;
            return View();
        }
        //view component
        public IActionResult component()
        {
            return View();
        }
    }
}
