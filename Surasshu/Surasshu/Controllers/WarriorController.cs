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

            if (Request.Form["ImageBox"] == "")
            {
                if (warrior.IsNinja)
                {
                    warrior.ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQGz5BR-UzS0eqX5j5iYeQ2VZjTjqa2rC31Nw-Xjnh6CJ1l9PlmYEyp2dwTe0_lzB1xnA&usqp=CAU";
                } else if (!warrior.IsNinja)
                {
                    warrior.ImageLink = "https://static.vecteezy.com/system/resources/previews/005/644/134/original/clip-art-of-samurai-with-silhouette-design-vector.jpg";
                } 
            }
            else
            {
                warrior.ImageLink = Request.Form["ImageBox"];
            }

            dal.AddWarrior(warrior);

            return View("WarriorLocker", dal.GetWarriors(loggedInUser));
        }

        public IActionResult DeleteWarrior(int id)
        {
            var loggedInUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            dal.DeleteWarrior(id);

            return View("WarriorLocker", dal.GetWarriors(loggedInUser));
        }

        public IActionResult SearchBattlePage()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            return View("SearchForBattle", dal.GetWarriors(userId));
        }

       // Uncomment this AFTER you design the battlefield itself
        public IActionResult SendOutToSoloBattle(int? id)
        {
            /*
             * So this is when we get a bit spicy
             * Rather than having the actual code for the battle itself here...
             * We're going to simply have the necessary fields for copies of the user's warriors and then send them to the cshtml itself
             * and then have the code for the battle occur in the cshtml itself...
             * Crazy right?
            */

            var w1 = dal.GetWarrior(id);
            var w2 = dal.GetWarrior(random.Next(1, dal.GetWarriorTableCount()));
            do 
            {
                w2 = dal.GetWarrior(random.Next(dal.GetWarriorTableCount()));
            } while (w1.UserId == w2.UserId);

            var participants = new List<Warrior> { w1, w2 };

            return View("Battlefield", participants);
        }
        

       /* public IActionResult SendOutToSoloBattle()
       {
           return View("Battlefield");
       } */
    }
}
