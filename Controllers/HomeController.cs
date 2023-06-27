using CLDV6221_PoE_Part3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CLDV6221_PoE_Part3.Controllers
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
            Loggedin.bLoggedIn = false; //do not show the menue item default to not logged in 
            ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();

            return View();
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
// the above code was genertated by Visual Studio Nuget Packet Manager and was adapted to my liking.