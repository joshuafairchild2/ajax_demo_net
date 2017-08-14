using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private AjaxDemoContext db = new AjaxDemoContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HelloAjax()
        {
            return Content("Hello from the controller!", "text/plain");
        }

        public IActionResult Sum(int firstNumber, int secondNumber)
        {
            return Content((firstNumber + secondNumber).ToString(), "text/plain");
        }

        public IActionResult DisplayObject()
        {
            Destination destination = new Destination("Portland", "Oregon", 1);
            return Json(destination);
        }

        public IActionResult DisplayViewWithAjax()
        {
            return View();
        }

        public IActionResult RandomDestinationList(int destinationCount)
        {
            IQueryable<Destination> randList = db.Destinations.OrderBy(r => Guid.NewGuid()).Take(destinationCount);

            return Json(randList);
        }

        [HttpPost]
        public IActionResult NewDestination(string newCity, string newCountry)
        {
            Destination newDestination = new Models.Destination(newCity, newCountry);
            db.Destinations.Add(newDestination);
            db.SaveChanges();
            return Json(newDestination);
        }
    }
}
