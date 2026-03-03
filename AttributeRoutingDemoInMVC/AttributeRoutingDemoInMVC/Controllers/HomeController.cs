//using AttributeRoutingDemoInMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AttributeRoutingDemoInMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Optional Parameter
        // URL: /MVCTest/
        // URL: /MVCTest/Pranaya
        [Route("MVCTest/{studentName?}")]
        public IActionResult MVC(string studentname)
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

        // Optional Parameter with default value
        // URL: /WEBAPITest/
        // URL: /WEBAPITest/Pranaya
        [Route("WEBAPITest/{studentName = Pranaya}")]
        public IActionResult WEBAPI(string studentName)
        {
            ViewBag.Message = "Welcome to ASP.NET WEB API!";
            return View();
        }
    }
}
