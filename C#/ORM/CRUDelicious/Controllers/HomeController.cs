using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers
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
            ViewBag.RecentDishes = dbContext.Dishes.OrderByDescending(dish => dish.id).Take(5);
            return View();
        }

        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View();
        }

        [HttpPost("add_dish")]
        public dynamic AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish");
            }
        }

        [HttpGet("{dishId}")]
        public IActionResult DishInfo(int dishId)
        {
            Dish dishInfo = dbContext.Dishes.FirstOrDefault(dish => dish.id == dishId);

            return View(dishInfo);
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish deleteDish = dbContext.Dishes.FirstOrDefault(dish => dish.id == dishId);
            dbContext.Dishes.Remove(deleteDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish editDish = dbContext.Dishes.FirstOrDefault(dish => dish.id == dishId);
            return View(editDish);
        }

        [HttpPost("edit")]
        public IActionResult Edit(Dish editedDish)
        {
            Dish updateDish = dbContext.Dishes.FirstOrDefault(dish => dish.id == editedDish.id);
            if (ModelState.IsValid)
            {
                updateDish.Name = editedDish.Name;
                updateDish.Chef = editedDish.Chef;
                updateDish.Tastiness = editedDish.Tastiness;
                updateDish.Calories = editedDish.Calories;
                updateDish.updated_at = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("DishInfo",new{dishId = updateDish.id});
            }
            else
            {
                return View("EditDish",updateDish);
            }

        }
    }
}