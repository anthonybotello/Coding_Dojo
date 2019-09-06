using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count",1);
            }
            else
            {
                int _count = (int)HttpContext.Session.GetInt32("count");
                _count++;
                HttpContext.Session.SetInt32("count",_count);
            }
            string passcode = "";
            Random random = new Random();
            for (int i = 1; i <= 14; i++)
            {
                passcode += Convert.ToChar(random.Next(33,124)).ToString();
            }
            ViewBag.Passcode = passcode;
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            return View();
        }
    }
}