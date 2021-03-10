using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Highfield.Recruitment.Models;
using Highfield.Recruitment.Business.Users;

namespace Highfield.Recruitment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserProvider userProvider;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.userProvider = new UserProvider();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Task()
        {
            var model = this.userProvider.GetUserData();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
