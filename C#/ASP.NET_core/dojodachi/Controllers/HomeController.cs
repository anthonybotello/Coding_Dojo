using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Dojodachi myDojodachi;
            ViewBag.Message = "";
            if (HttpContext.Session.GetString("dojodachi") == null)
            {
                myDojodachi = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("dojodachi",myDojodachi);
                ViewBag.Message = "Play with your Dojodachi!";
            }
            else
            {
                myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dojodachi");
                if (myDojodachi.Happiness >= 100 && myDojodachi.Fullness >= 100)
                {
                    ViewBag.Message = "Congratulations! A winner is you!";
                }
                else if (myDojodachi.Happiness <= 0)
                {
                    myDojodachi.Happiness = 0;
                    ViewBag.Message = "Your Dojodachi got tired of your shit and left.";
                }
                else if (myDojodachi.Fullness <= 0)
                {
                    myDojodachi.Fullness = 0;
                    ViewBag.Message = "Nice job. Your Dojodachi starved to death.";
                }
                else
                {
                    ViewBag.Message = TempData["Message"];
                }
            }
            return View(myDojodachi);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Random random = new Random();
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dojodachi");
            int meals = myDojodachi.Meals;
            if (meals > 0)
            {
                meals--;
                myDojodachi.Meals = meals;
                int deltaFull = random.Next(5,11);
                if (random.Next(1,5) == 1)
                {
                    myDojodachi.Fullness -= deltaFull;
                    TempData["Message"] = $"Your Dojodachi didn't like your food. Fullness -{deltaFull}, Meals -1";
                }
                else
                {
                    myDojodachi.Fullness += deltaFull;
                    TempData["Message"] = $"You fed your Dojodachi. Fullness +{deltaFull}, Meals -1";
                }
                HttpContext.Session.SetObjectAsJson("dojodachi",myDojodachi);
            }
            else
            {
                TempData["Message"] = "Out of meals! Work to get more!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Random random = new Random();
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dojodachi");
            int energy = myDojodachi.Energy;
            if (energy > 0)
            {
                energy -= 5;
                myDojodachi.Energy = energy;
                int deltaHappy = random.Next(5,11);
                if (random.Next(1,5) == 1)
                {
                    myDojodachi.Happiness -= deltaHappy;
                    TempData["Message"] = $"Your Dojodachi didn't like how you played with it. Happiness -{deltaHappy}, Energy -5";
                }
                else
                {
                    myDojodachi.Happiness += deltaHappy;
                    TempData["Message"] = $"You played with your Dojodachi! Happiness +{deltaHappy}, Energy -5";
                }
                HttpContext.Session.SetObjectAsJson("dojodachi",myDojodachi);
            }
            else
            {
                TempData["Message"] = "Your Dojodachi is too tired to play. Stop being selfish and let it sleep.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Random random = new Random();
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dojodachi");
            int energy = myDojodachi.Energy;
            if (energy > 0)
            {
                energy -= 5;
                myDojodachi.Energy = energy;
                if (random.Next(1,5) == 1)
                {
                    TempData["Message"] = "Your Dojodachi tried to work but it has no life skills. Energy -5";
                }
                else
                {
                    int deltaMeals = random.Next(1,4);
                    myDojodachi.Meals += deltaMeals;
                    TempData["Message"] = $"Your Dojodachi got its life together for a bit and did some work! Meals +{deltaMeals}, Energy -5";
                }
                HttpContext.Session.SetObjectAsJson("dojodachi",myDojodachi);
            }
            else
            {
                TempData["Message"] = "Your Dojodachi cited your state's child labor laws and threatened to report you if you don't let it sleep.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Random random = new Random();
            Dojodachi myDojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dojodachi");
            myDojodachi.Fullness -= 5;
            myDojodachi.Happiness -=5;
            if (random.Next(1,5) == 1)
            {
                myDojodachi.Happiness -= 5;
                TempData["Message"] = "Your Dojodachi had a nightmare. Fullness -5, Happiness -10";
            }
            else
            {
                myDojodachi.Energy += 15;
                TempData["Message"] = "Your Dojodachi had a niiiice dream. Energy +15, Fullness -5, Happiness -5";
            }
            HttpContext.Session.SetObjectAsJson("dojodachi",myDojodachi);
            return RedirectToAction("Index");
        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}