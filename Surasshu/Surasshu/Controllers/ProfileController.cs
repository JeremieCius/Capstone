using Microsoft.AspNetCore.Mvc;

namespace Surasshu.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
