using System.Diagnostics;
using HotelBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Web.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Error()
        {
            return View();
        }
    }
}
