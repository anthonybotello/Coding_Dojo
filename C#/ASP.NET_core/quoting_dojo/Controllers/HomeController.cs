using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;
using DbConnection;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost("addquote")]
        public IActionResult AddQuote(Quote quote)
        {
            string query = $"INSERT INTO quotes (name,quote) VALUES ('{quote._Name}','{quote._Quote}')";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");
        }

        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.Quotes = AllQuotes;
            return View();
        }
    }
}