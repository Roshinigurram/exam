using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcforassessment.Controllers
{
    public class SessionandCookieController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "roshini");
            var name = HttpContext.Session.GetString("Name");

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(4)
            };

            HttpContext.Response.Cookies.Append("Address", "Hitech City, Hyderabad", options);

            return View();
        }

        public IActionResult Get()
        {
            string address = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Address", out address);
            return View();
        }
   
        }
        
    }

