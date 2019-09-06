using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using viewmodel_fun.Models;

namespace viewmodel_fun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string message = "The sine-Gordon equation is a nonlinear hyperbolic partial differential equation in 1 + 1 dimensions involving the d'Alembert operator and the sine of the unknown function. It was originally introduced by Edmond Bour (1862) in the course of study of surfaces of constant negative curvature as the Gauss–Codazzi equation for surfaces of curvature −1 in 3-space, and rediscovered by Frenkel and Kontorova (1939) in their study of crystal dislocations known as the Frenkel–Kontorova model. This equation attracted a lot of attention in the 1970s due to the presence of soliton solutions.";
            return View("Index",message);
        }

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = {1,2,3,10,43,5};
            return View(numbers);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            List<User> users = new List<User>(){
                new User("Moose","Phillips"),
                new User("Sara",""),
                new User("Jerry",""),
                new User("Rene","Ricky"),
                new User("Barbarah","")
            };
            return View(users);
        }

        [HttpGet("user")]
        public IActionResult _User()
        {
            return View(new User("Moose","Phillips"));
        }
    }
}
