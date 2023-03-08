using Microsoft.AspNetCore.Mvc;
using Surasshu.Models;
using System.Diagnostics;
using System.Security.Claims;
using Surasshu.Interfaces;

namespace Surasshu.Controllers
{
    public class HomeController : Controller
    {
        IDataAccessLayer dal;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDataAccessLayer indal)
        {
            dal = indal;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var view = View("Index");
            if (userId == null)
            {
                return view;
            }
            else
            {
                view = View("Index", dal.GetUser(userId));
            }

            return view;
        }

        public IActionResult About()
        {
            return View("About");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult AboutNinja()
        {
            return View();
        }

        public IActionResult AboutSamurai()
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