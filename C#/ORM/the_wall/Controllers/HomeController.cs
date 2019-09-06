using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using the_wall.Models;
namespace the_wall.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("wall")]
        public IActionResult Index()
        {
            ViewBag.User = HttpContext.Session.GetObjectFromJson<User>("CurrentUser");
            if (ViewBag.User == null)
            {
                return RedirectToAction("Index","Login");
            }
            ViewBag.Messages = dbContext.Messages
            .Include(m => m.Creator)
            .Include(m => m.Comments)
            .ThenInclude(c => c.User)
            .OrderByDescending(m => m.MessageId)
            .ToList();
            
            return View();
        }

        [HttpPost("add_message")]
        public IActionResult AddMessage(IndexViewModel newMsg)
        {
            if (HttpContext.Session.GetObjectFromJson<User>("CurrentUser") == null)
            {
                return RedirectToAction("Index","Login");
            }
            if (ModelState.IsValid)
            {
                dbContext.Messages.Add(newMsg.NewMessage);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.User = HttpContext.Session.GetObjectFromJson<User>("CurrentUser");
                ViewBag.Messages = dbContext.Messages
                .Include(m => m.Creator)
                .Include(m => m.Comments)
                .ThenInclude(c => c.User)
                .OrderByDescending(m => m.MessageId)
                .ToList();
                return View("Index");
            }
        }

        [HttpPost("add_comment")]
        public IActionResult AddComment(IndexViewModel newCmt)
        {
            if (HttpContext.Session.GetObjectFromJson<User>("CurrentUser") == null)
            {
                return RedirectToAction("Index","Login");
            }
            if (ModelState.IsValid)
            {
                dbContext.Comments.Add(newCmt.NewComment);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.User = HttpContext.Session.GetObjectFromJson<User>("CurrentUser");
                ViewBag.Messages = dbContext.Messages
                .Include(m => m.Creator)
                .Include(m => m.Comments)
                .ThenInclude(c => c.User)
                .OrderByDescending(m => m.MessageId)
                .ToList();
                return View("Index");
            }
        }

        [HttpGet("delete/message/{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            User CurrentUser = HttpContext.Session.GetObjectFromJson<User>("CurrentUser");
            if (CurrentUser == null)
            {
                return RedirectToAction("Index","Login");
            }
            Message delMsg = dbContext.Messages.FirstOrDefault(m => m.MessageId == messageId);
            if(delMsg == null)
            {
                return RedirectToAction("Index");
            }
            TimeSpan interval = DateTime.Now - delMsg.CreatedAt;
            if (CurrentUser.UserId == delMsg.UserId && interval.TotalMinutes < 30.00)
            {
                dbContext.Messages.Remove(delMsg);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("delete/comment/{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            User CurrentUser = HttpContext.Session.GetObjectFromJson<User>("CurrentUser");
            if (CurrentUser == null)
            {
                return RedirectToAction("Index","Login");
            }
            Comment delCmt = dbContext.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (delCmt == null)
            {
                return RedirectToAction("Index");
            }
            TimeSpan interval = DateTime.Now - delCmt.CreatedAt;
            if (CurrentUser.UserId == delCmt.UserId && interval.TotalMinutes < 30.00)
            {
                dbContext.Comments.Remove(delCmt);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}