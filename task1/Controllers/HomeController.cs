using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using task1.Models;

namespace task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Service service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,Service service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmailDefault()
        {
            string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            service.SendEmailDefault(userid);
            return RedirectToAction("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
