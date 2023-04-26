using Lena.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lena.UI.Controllers
{
    public class FormsController : Controller
    {
        private readonly ILogger<FormsController> _logger;

        public FormsController(ILogger<FormsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}