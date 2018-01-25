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
            ViewBag.Category = new SelectList(Category.GetCategories(), "CategoryName", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Index(string symbol, string categoryname)
        {
            Console.WriteLine("You are here");
            Console.WriteLine(categoryname);
            ViewBag.Country = new SelectList(Country.GetCountries(), "Symbol", "Name");
            ViewBag.Category = new SelectList(Category.GetCategories(), "CategoryName", "Title");


            return RedirectToAction("GetHeadlines", "symbol", "categoryname");
        }

        public IActionResult GetHeadlines(string country, string category)
        {
            if( country == null && category == null)
            {
                country = "us";
                category = "";
            } 
                
            var allHeadlines = NewsItem.GetHeadlines(country, category);
            return View(allHeadlines);
        }

        public IActionResult UpdateHeadlines(string country, string category)
        {
            if (country == null && category == null)
            {
                country = "us";
                category = "";
                Console.WriteLine("YOU DIDNT GET THE COUNTRY IN HERE");
            }

            var newHeadlines = NewsItem.GetHeadlines(country, category);
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
