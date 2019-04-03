using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11_MVC.Models;

namespace Lab11_MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index( int priceMax, int pointMin )
        {
            // send to new pages
            return RedirectToAction("SearchResults", new { priceMax, pointMin });
        }

        [HttpGet]
        public IActionResult SearchResults(int priceMax, int pointMin)
        {
            List<Wine> wineSelect = Wine.GetWineList( priceMax, pointMin );

            return View( wineSelect );
        }

    }
}
