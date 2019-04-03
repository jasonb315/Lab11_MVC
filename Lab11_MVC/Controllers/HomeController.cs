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
        /// <summary>
        ///     Home page / Index View
        /// </summary>
        /// <returns>Index View</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Redirects user to SearchResults on Index Post
        /// </summary>
        /// <param name="priceMax">input priceMax</param>
        /// <param name="pointMin">input pointMin</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Index( int priceMax, int pointMin )
        {
            // send to diff page
            return RedirectToAction("SearchResults", new { priceMax, pointMin });
        }

        /// <summary>
        ///     Page View method for SeatchResults
        /// </summary>
        /// <param name="priceMax">input priceMax</param>
        /// <param name="pointMin">input pointMin</param>
        /// <returns>SearchResults View</returns>
        [HttpGet]
        public IActionResult SearchResults(int priceMax, int pointMin)
        {
            List<Wine> wineSelect = Wine.GetWineList( priceMax, pointMin );

            return View( wineSelect );
        }

    }
}
