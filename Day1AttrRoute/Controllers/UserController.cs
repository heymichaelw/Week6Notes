using Day1AttrRoute.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1AttrRoute.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("u/{userName}")]
        public ActionResult Detail(string userName)
        {
            ApplicationUser userInstance = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            return View(userInstance);
        }
    }
}