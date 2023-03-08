using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
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
            warrior.WarriorId = dal.GetWarriorHighestIndexCount() + 1;
            warrior.WarriorName = Request.Form["NameBox"];
            warrior.Level = 1;
            warrior.Xp = 0;
            warrior.QuirkOneId = 16;
            warrior.QuirkTwoId = 16;
            warrior.QuirkThreeId = 16;

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
                warrior.DieCount = 1;
                warrior.DieSide = 8;
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
            if (Request.Form["txtDelete"] == "DELETE ME")
            {
                dal.DeleteWarrior(id);
            }

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
            var w2 = dal.GetWarrior(random.Next(1, dal.GetWarriorHighestIndexCount()));

            var levelRange = -999999;


            if (w2 == null || w1.UserId == w2.UserId || levelRange is >= 3 and <= 3)
            {
                do
                {
                    w2 = dal.GetWarrior(random.Next(1, dal.GetWarriorHighestIndexCount()));
                    if(w2 != null) 
                    { levelRange = w1.Level - w2.Level; }

                } while (w2 == null || w1.UserId == w2.UserId || levelRange is >= 3 and <= 3);
            }

            var participants = new List<Warrior> { w1, w2 };

            return View("Battlefield", participants);
        }

        [HttpPost]
        public IActionResult EquipWithQuirkPage(int id)
        {
            return View("EquipWithQuirkPage", dal.GetWarrior(id));
        }

        [HttpPost]
        public IActionResult EquipNinjaWithQuirks(int id)
        {
            var q1Name = Request.Form["QuirkOne"];
            var q2Name = Request.Form["QuirkTwo"];
            var q3Name = Request.Form["QuirkThree"];

            if ((q1Name == q2Name || q2Name == q3Name || q3Name == q1Name) && 
                ((q1Name != "None" && q2Name != "None") || (q2Name != "None" && q3Name != "None") || 
                 (q1Name != "None" && q3Name != "None") || (q1Name != "None" && q2Name != "None" && q3Name != "None")))
            {
                ModelState.AddModelError("ninja-error",
                    "NO DUPLICATES");
                return EquipWithQuirkPage(id);
            }

            if ((q2Name == "Master Assassin" && q1Name != "Assassin") && 
                (q3Name == "Master Assassin" && q2Name != "Assassin") &&
                (q3Name == "Master Assassin" && q1Name != "Assassin"))
            {
                ModelState.AddModelError("ninja-error", 
                    "Ninja must have the quirk 'Assassin' equipped in the 1st or 2nd slot before equipping 'Master Assassin' in 2nd or 3rd slot");
                return EquipWithQuirkPage(id);
            }

            if ((q2Name == "Finesse" && q1Name != "Nimble") &&
                (q3Name == "Finesse" && q2Name != "Nimble") &&
                (q3Name == "Finesse" && q1Name != "Nimble"))
            {
                ModelState.AddModelError("ninja-error",
                    "Ninja must have the quirk 'Nimble' equipped in the 1st or 2nd slot before equipping 'Finesse' in 2nd or 3rd slot");
                return EquipWithQuirkPage(id);
            }

            if ((q2Name == "Crit-Quencher" && q1Name != "Assassin") &&
                (q3Name == "Crit-Quencher" && q2Name != "Assassin") &&
                (q3Name == "Crit-Quencher" && q1Name != "Assassin"))
            {
                ModelState.AddModelError("ninja-error",
                    "Ninja must have the quirk 'Assassin' equipped in the 1st or 2nd slot before equipping 'Crit-Quencher' in 2nd or 3rd slot");
                return EquipWithQuirkPage(id);
            }

            if (q3Name == "Uncanny Dodge" && q2Name != "Finesse")
            {
                ModelState.AddModelError("ninja-error",
                    "Ninja must have the quirk 'Finesse' equipped in the 2nd slot before equipping 'Uncanny Dodge' in the 3rd slot");
                return EquipWithQuirkPage(id);
            }

            if ((q2Name == "Fury" && q1Name != "Frenzy") ||
               (q3Name == "Fury" && q2Name != "Frenzy"))
            {
                ModelState.AddModelError("ninja-error",
                    "Ninja must have the quirk 'Frenzy' equipped in the 1st or 2nd slot before equipping 'Fury' in 2nd or 3rd slot");
                return EquipWithQuirkPage(id);
            }

            var q1 = dal.GetQuirkByName(q1Name);
            var q2 = dal.GetQuirkByName(q2Name);
            var q3 = dal.GetQuirkByName(q3Name);

            dal.EquipNinjaWithQuirk(id, q1, q2, q3);

            return WarriorLocker();
        }

        [HttpPost]
        public IActionResult EquipSamuraiWithQuirks(int id)
        {
            var q1Name = Request.Form["QuirkOne"];
            var q2Name = Request.Form["QuirkTwo"];

            if (q1Name == q2Name)
            {
                if (q1Name == "None" && q2Name == "None")
                {
                    
                }
                else
                {
                    ModelState.AddModelError("samurai-error",
                        "NO DUPLICATES");
                    return EquipWithQuirkPage(id);
                }
            }

            if (q2Name == "Deflect" && q1Name != "Parry")
            {
                ModelState.AddModelError("samurai-error",
                    "Samurai must have 'Parry' equipped in the 1st slot before equipping 'Deflect'");
                return EquipWithQuirkPage(id);
            }

            if (q2Name == "Execution" && q1Name != "Punish")
            {
                ModelState.AddModelError("samurai-error",
                    "Samurai must have 'Punish' equipped in the 1st slot before equipping 'Execution'");
                return EquipWithQuirkPage(id);
            }

            if (q2Name == "Unkillable" && q1Name != "Toughness")
            {
                ModelState.AddModelError("samurai-error",
                    "Samurai must have 'Toughness' equipped in the 1st slot before equipping 'Unkillable'");
                return EquipWithQuirkPage(id);
            }

            var q1 = dal.GetQuirkByName(q1Name);
            var q2 = dal.GetQuirkByName(q2Name);

            dal.EquipSamuraiWithQuirk(id, q1, q2);

            return WarriorLocker();
        }
    }
}
