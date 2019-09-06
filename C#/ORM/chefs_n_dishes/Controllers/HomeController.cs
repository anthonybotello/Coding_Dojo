using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using chefs_n_dishes.Models;
namespace chefs_n_dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> chefs = dbContext.Chefs.ToList();

            foreach (Chef chef in chefs)
            {
                chef.CreatedDishes = dbContext.Dishes.Where(dish => dish.ChefId == chef.ChefId).ToList();
            }
            return View(chefs);
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> dishes = dbContext.Dishes.ToList();
            foreach (Dish dish in dishes)
            {
                dish.Creator = dbContext.Chefs.FirstOrDefault(chef => chef.ChefId == dish.ChefId);
            }
            return View(dishes);
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                dbContext.Chefs.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.Chefs = dbContext.Chefs.ToList();
            return View();
        }

        [HttpPost("dishes/add")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                int chef_id = newDish.ChefId;
                Chef chef = dbContext.Chefs.FirstOrDefault(_chef => _chef.ChefId == chef_id);
                chef.CreatedDishes.Add(newDish);
                newDish.Creator = chef;
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ViewBag.Chefs = dbContext.Chefs.ToList();
                return View("NewDish");
            }
        }
    }
}