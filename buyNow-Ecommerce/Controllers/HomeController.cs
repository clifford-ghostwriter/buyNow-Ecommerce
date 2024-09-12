using System;
using System.Diagnostics;
//using buyNow_Ecommerce;
using buyNow.BAL.Models;
using Microsoft.AspNetCore.Mvc;


namespace buyNow_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			TempData["ToastrMessage"] = "Form submitted successfully!";
			TempData["ToastrType"] = "success"; // You can pass an alert type like 'success', 'danger', etc.
			return View();
        }

        public IActionResult Privacy()
        {
            return View("test");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
