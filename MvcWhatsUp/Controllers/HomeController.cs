using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MvcWhatsUp.Models;
using System.Diagnostics;

namespace MvcWhatsUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HomeIndex()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string GetAllStudents()
        {
            return "Displaying all students...";
        }
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public string SendMessage(string name, string message)
        {
            return $"Message {message} has been send by {name}";
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(string name, string password)
        {
            return $"Successfully logged in as user: {name} and password: {password}";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
