using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Surasshu.Areas.Identity.Data;
using Surasshu.Data;
using Surasshu.Interfaces;

namespace Surasshu.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<SurasshuUser> _userManager;

        IDataAccessLayer dal;

        public ProfileController(IDataAccessLayer indal, SurasshuContext inContext, UserManager<SurasshuUser> userManager)
        {
            this.dal = indal;
            this._userManager = userManager;
            if (inContext.GetType() == typeof(SurasshuDAL))
            {
                ((SurasshuDAL)dal).db = inContext;
            }
        }
        public IActionResult GetProfile(string userId)
        {
            List<SurasshuUser> list = new List<SurasshuUser>();
            list.Add(dal.GetUser(userId));
            return View("Profile", list);
        }

        [HttpPost]
        public IActionResult UpdateProfile(SurasshuUser user)
        {
            var loggedInUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = dal.GetUser(loggedInUser);
            user.FirstName = Request.Form["FNameBox"];
            user.LastName = Request.Form["LNameBox"];
            user.UserName = Request.Form["UNameBox"];
            user.PhoneNumber = Request.Form["PhoneBox"];

            dal.UpdateUser(user);

            List<SurasshuUser> list = new List<SurasshuUser>();
            list.Add(user);

            return View("Profile", list);
        }
    }
}
