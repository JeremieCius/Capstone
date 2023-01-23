using Microsoft.AspNetCore.Mvc;
using Surasshu.Interfaces;

namespace Surasshu.Controllers
{
    public class WarriorController : Controller
    {
        IDataAccessLayer dal;

        public WarriorController(IDataAccessLayer indal)
        {
            this.dal = indal;
        }

        public IActionResult WarriorLocker()
        {
            return View("WarriorLocker", dal.GetWarriors());
        }

        
    }
}
