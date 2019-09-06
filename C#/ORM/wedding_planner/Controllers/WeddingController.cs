using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wedding_planner.Models;
namespace wedding_planner.Controllers
{
    public class WeddingController : Controller
    {
        private MyContext dbContext;

        public WeddingController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("/dashboard")]
        public IActionResult Index()
        {
            User currentUser = HttpContext.Session.GetObjectFromJson<User>("CurrentUser");
            currentUser.Weddings = dbContext.RSVPs
            .Include(r => r.Wedding)
            .Where(r => r.UserId == currentUser.UserId)
            .ToList();

            List<Wedding> allWed = dbContext.Weddings
            .Include(wed => wed.Guests)
            .ToList();
            
            ViewBag.Weddings = allWed.Except(
                currentUser.Weddings
                .Select(w => w.Wedding)
            );
            return View(currentUser);
        }

        [HttpGet("weddings/new")]
        public IActionResult NewWedding()
        {
            ViewBag.CreatorId = HttpContext.Session.GetObjectFromJson<User>("CurrentUser").UserId;
            return View();
        }

        [HttpPost("weddings/add")]
        public IActionResult AddWedding(Wedding newWed)
        {
            if (ModelState.IsValid)
            {
                dbContext.Addresses.Add(newWed.WeddingAddress);
                dbContext.Weddings.Add(newWed);
                dbContext.SaveChanges();
                Address lastadd = dbContext.Addresses.Last();
                Wedding lastwed = dbContext.Weddings.Last();
                lastwed.AddressId = lastadd.AddressId;
                lastadd.WeddingId = lastwed.WeddingId;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CreatorId = HttpContext.Session.GetObjectFromJson<User>("CurrentUser").UserId;
                return View("NewWedding");
            }
        }

        [HttpGet("/rsvp/{userId}/{weddingId}")]
        public IActionResult NewRSVP(int userId, int weddingId)
        {
            RSVP newRSVP = new RSVP();
            newRSVP.UserId = userId;
            newRSVP.WeddingId = weddingId;
            dbContext.RSVPs.Add(newRSVP);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/un-rsvp/{rsvpId}")]
        public IActionResult UnRSVP(int rsvpId)
        {

            RSVP unrsvp = dbContext.RSVPs.FirstOrDefault(r => r.RSVPId == rsvpId);
            dbContext.RSVPs.Remove(unrsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {
            Wedding deleteWed = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            dbContext.Weddings.Remove(deleteWed);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("weddings/{weddingId}")]
        public IActionResult ViewWedding(int weddingId)
        {
            Wedding viewWedding = dbContext.Weddings
            .Include(w => w.Guests)
            .ThenInclude(g => g.User)
            .FirstOrDefault(wed => wed.WeddingId == weddingId);

            viewWedding.WeddingAddress = dbContext.Addresses.FirstOrDefault(a => a.AddressId == viewWedding.AddressId);
            return View(viewWedding);
        }
    }
}