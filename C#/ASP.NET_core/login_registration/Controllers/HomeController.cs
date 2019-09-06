using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using login_registration.Models;


namespace login_registration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(IndexViewModel modelData)
        {
            Registration newRegistration = modelData.NewRegistration;
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(IndexViewModel modelData)
        {
            Login userLogin = modelData.UserLogin;
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet("success")]
        public string Success()
        {
            return "You are success!";
        }
    }
}
