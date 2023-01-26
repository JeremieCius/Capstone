using Microsoft.AspNetCore.Mvc;
using Surasshu.Interfaces;
using Surasshu.Models;

namespace Surasshu.Controllers
{
    public class WarriorController : Controller
    {
        IDataAccessLayer dal;

        private Random random;

        public WarriorController(IDataAccessLayer indal)
        {
            this.dal = indal;
        }

        public IActionResult WarriorLocker()
        {
            return View("WarriorLocker", dal.GetWarriors());
        }

        [HttpPost]
        public IActionResult CreateWarrior()
        {
            Warrior warrior = new Warrior();
            warrior.WarriorId = dal.GetWarriors().Count() + 1;
            warrior.WarriorName = Request.Form["NameBox"];
            if (Request.Form["SelectWarriorType"] == "Ninja")
            {
                warrior.IsNinja = true;
            } else if (Request.Form["SelectWarriorType"] == "Samurai")
            {
                warrior.IsNinja = false;
            } else if (Request.Form["SelectWarriorType"] != "Ninja" && Request.Form["SelectWarriorType"] != "Samurai")
            {
                warrior.IsNinja = true;
            }



            return View("WarriorLocker", dal.GetWarriors());
        }
    }
}
