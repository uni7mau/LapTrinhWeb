using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenDucThach_231230898_de02.Models;

namespace NguyenDucThach_231230898_de02.Controllers
{
    public class ndtHomeController : Controller
    {
        private readonly ILogger<ndtHomeController> _logger;

        public ndtHomeController(ILogger<ndtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ndtIndex()
        {
            return View();
        }

        public IActionResult ndtPrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ndtError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
