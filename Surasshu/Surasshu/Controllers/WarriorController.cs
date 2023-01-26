using Microsoft.AspNetCore.Mvc;
using Surasshu.Data;
using Surasshu.Interfaces;
using Surasshu.Models;

namespace Surasshu.Controllers
{
    public class WarriorController : Controller
    {
        IDataAccessLayer dal;

        private Random random;

        public WarriorController(IDataAccessLayer indal, SurasshuContext inContext)
        {
            this.dal = indal;
            if (inContext.GetType() == typeof(SurasshuDAL))
            {
                ((SurasshuDAL)dal).db = inContext;
            }
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
            warrior.Xp = 0;
            warrior.Attack = 1;
            warrior.Defense = 12;
            warrior.Hp = random.Next(20, 25);
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
