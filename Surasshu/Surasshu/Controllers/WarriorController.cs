using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Surasshu.Areas.Identity.Data;
using Surasshu.Data;
using Surasshu.Interfaces;
using Surasshu.Models;

namespace Surasshu.Controllers
{
    public class WarriorController : Controller
    {
        private readonly UserManager<SurasshuUser> _userManager;

        IDataAccessLayer dal;

        private Random random = new Random();

        public WarriorController(IDataAccessLayer indal, SurasshuContext inContext, UserManager<SurasshuUser> userManager)
        {
            this.dal = indal;
            this._userManager = userManager;
            if (inContext.GetType() == typeof(SurasshuDAL))
            {
                ((SurasshuDAL)dal).db = inContext;
            }
        }

        public IActionResult WarriorLocker()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            return View("WarriorLocker", dal.GetWarriors(userId));
        }

        [HttpPost]
        public IActionResult CreateWarrior()
        {
            var loggedInUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Warrior warrior = new Warrior();
            warrior.UserId = loggedInUser;
            warrior.WarriorId = dal.GetWarriorTableCount() + 1;
            warrior.WarriorName = Request.Form["NameBox"];
            warrior.Xp = 0;
            warrior.QuirkOneId = null;
            warrior.QuirkTwoId = null;
            warrior.QuirkThreeId = null;

            if (Request.Form["SelectWarriorType"] == "Ninja")
            {
                warrior.IsNinja = true;
                warrior.AttackMod = 1;
                warrior.DieCount = 2;
                warrior.DieSide = 4;
                warrior.Crit = 2;
                warrior.Defense = random.Next(11, 13);
                warrior.Hp = random.Next(20, 25);

            } else if (Request.Form["SelectWarriorType"] == "Samurai")
            {
                warrior.IsNinja = false;
                warrior.AttackMod = 1;
                warrior.DieCount = 2;
                warrior.DieSide = 4;
                warrior.Crit = 2;
                warrior.Defense = random.Next(13, 15);
                warrior.Hp = random.Next(27, 31);
            } else if (Request.Form["SelectWarriorType"] != "Ninja" && Request.Form["SelectWarriorType"] != "Samurai")
            {
                warrior.IsNinja = true;
                warrior.AttackMod = 1;
                warrior.DieCount = 2;
                warrior.DieSide = 4;
                warrior.Crit = 2;
                warrior.Defense = random.Next(11, 13);
                warrior.Hp = random.Next(20, 25);
            }

            dal.AddWarrior(warrior);

            return View("WarriorLocker", dal.GetWarriors(loggedInUser));
        }

    }
}
