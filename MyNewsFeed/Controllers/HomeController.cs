using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyNewsFeed.Models;
using MyNewsFeed.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyNewsFeed.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Country = new SelectList(Country.GetCountries(), "Symbol", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Index(string symbol)
        {
            ViewBag.Country = new SelectList(Country.GetCountries(), "Symbol", "Name");



            return RedirectToAction("GetHeadlines", "symbol");
        }

        public IActionResult GetHeadlines(string country)
        {
            if( country == null)
            {
                country = "us";
            } 
                
            var allHeadlines = NewsItem.GetHeadlines(country);
            return View(allHeadlines);
        }

        public IActionResult UpdateHeadlines(string country)
        {
            if (country == null)
            {
                country = "us";
                Console.WriteLine("YOU DIDNT GET THE COUNTRY IN HERE");
            }

            var newHeadlines = NewsItem.GetHeadlines(country);
            return Json(newHeadlines);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
