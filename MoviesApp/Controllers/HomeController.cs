using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        // GET: /
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET: Home/Privacy
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}