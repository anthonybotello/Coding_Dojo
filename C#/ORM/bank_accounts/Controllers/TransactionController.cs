using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using bank_accounts.Models;
namespace bank_accounts.Controllers
{
    public class TransactionController : Controller
    {
        private MyContext dbContext;

        public TransactionController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("accounts/{userId}")]
        public IActionResult Index(int userId)
        {
            User user = dbContext.Users.FirstOrDefault(_user => _user.UserId == userId);
            user.UserTransactions = dbContext.Transactions.Where(t => t.UserId == user.UserId).OrderByDescending(t => t.TransactionId).ToList();
            ViewBag.User = user;
            return View();
        }

        [HttpPost("addtransaction")]
        public IActionResult AddTransaction(Transaction trans)
        {
            User user = dbContext.Users.FirstOrDefault(u => u.UserId == trans.UserId);
            user.UserTransactions = dbContext.Transactions.Where(t => t.UserId == user.UserId).OrderByDescending(t => t.TransactionId).ToList();
            if (ModelState.IsValid)
            {
                if ((double)trans.Amount + user.AccountBalance < 0)
                {
                    ModelState.AddModelError("Amount","Insufficient funds.");
                    ViewBag.User = user;
                    return View("Index");
                }
                user.AccountBalance += (double)trans.Amount;
                dbContext.Add(trans);
                dbContext.SaveChanges();
                return RedirectToAction("Index",new{userId = user.UserId});
            }
            else
            {
                ViewBag.User = user;
                return View("Index");
            }
        }
    }
}