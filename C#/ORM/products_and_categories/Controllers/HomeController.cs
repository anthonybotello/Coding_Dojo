using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using products_and_categories.Models;
namespace products_and_categories.Controllers
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
            return RedirectToAction("Products");
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            ViewBag.AllProducts = dbContext.Products.ToList();  
            return View();
        }

        [HttpPost("products/add")]
        public IActionResult AddProduct(Product newProd)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(newProd);
                dbContext.SaveChanges();
                return RedirectToAction("Products");
            }
            else
            {
                ViewBag.AllProducts = dbContext.Products.ToList(); 
                return View("Products");
            }
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = dbContext.Categories.ToList();
            return View();
        }

        [HttpPost("categories/add")]
        public IActionResult AddCategory(Category newCat)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(newCat);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                ViewBag.AllCategories = dbContext.Categories.ToList();
                return View("Categories");
            }
        }

        [HttpGet("products/{productId}")]
        public IActionResult ShowProduct(int productId)
        {
            Product product = dbContext.Products
            .FirstOrDefault(p => p.ProductId == productId);

            product.Categories = dbContext.Associations
            .Include(a => a.Category)
            .Where(a => a.ProductId == productId)
            .OrderBy(a=> a.CategoryId)
            .ToList();

            List<Category> notCats = dbContext.Categories
            .Except(product.Categories
                .Select(p => p.Category))
            .ToList();

            ViewBag.Nots = notCats;
            ViewBag.Product = product;
            return View();
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult ShowCategory(int categoryId)
        {
            Category category = dbContext.Categories
            .FirstOrDefault(c => c.CategoryId == categoryId);

            category.Products = dbContext.Associations
            .Include(a => a.Product)
            .Where(a => a.CategoryId == categoryId)
            .OrderBy(a => a.ProductId)
            .ToList();

            List<Product> notProds = dbContext.Products
            .Except(category.Products
                .Select(c => c.Product))
            .ToList();

            ViewBag.Nots = notProds;
            ViewBag.Category = category;
            return View();
        }

        [HttpPost("products/addcategory")]
        public IActionResult AddProductCategory(Association newAss)
        {
            dbContext.Associations.Add(newAss);
            dbContext.SaveChanges();
            return RedirectToAction("ShowProduct",new{productId = newAss.ProductId});
        }

        [HttpPost("categories/addproduct")]
        public IActionResult AddCategoryProduct(Association newAss)
        {
            dbContext.Associations.Add(newAss);
            dbContext.SaveChanges();
            return RedirectToAction("ShowCategory",new{categoryId = newAss.CategoryId});
        }
    }
}