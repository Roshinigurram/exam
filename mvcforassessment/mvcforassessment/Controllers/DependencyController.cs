using Microsoft.AspNetCore.Mvc;
using mvcforassessment.dependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcforassessment.Controllers
{
    public class DependencyController : Controller
    {
        private readonly IExample _example;
        public DependencyController(IExample example)
        {
            _example = example;
        }
        public IActionResult Index()
        {
            ViewBag.name = _example.sum(233, 56);

            return View();
        }
    }
}
