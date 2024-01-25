using HashCodes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcWebApp.Models;
using System.Diagnostics;

namespace HashCodes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GenerateHashCode()
        {
            return PartialView("_HashCodeResult");
        }

        [HttpPost]
        public IActionResult GenerateHashCode(string inputText, string algorithm)
        {
            string hashCode = "_HashCodeResult";

            switch (algorithm)
            {
                case "MD5":
                    hashCode = HashGenerator.GetMD5Hash(inputText);
                    break;

                case "SHA1":
                    hashCode = HashGenerator.GetSHA1Hash(inputText);
                    break;

                case "SHA256":
                    hashCode = HashGenerator.GetSHA256Hash(inputText);
                    break;

                default:
                    ViewBag.ErrorMessage = "Invalid algorithm selected.";
                    break;
            }

            ViewBag.HashCode = hashCode;
            return PartialView("_HashCodeResult");

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