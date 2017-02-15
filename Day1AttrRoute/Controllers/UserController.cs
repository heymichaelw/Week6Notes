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
            var me = User.Identity.GetUserId();
            var target = userInstance.Id;
            bool isFriend = db.Friends
                .Where(f => (f.RequestorId == me && f.TargetId == target) ||
                (f.TargetId == me && f.RequestorId == target))
                .Any();
            ViewBag.isFriend = isFriend;
            return View(userInstance);
        }

        [HttpPost]
        [Route("u/{userName}")]
        public ActionResult AddFriend(string userName)
        {
            var me = User.Identity.GetUserId();
            var target = db.Users.Where(u => u.UserName == userName).FirstOrDefault().Id;
            Friend relationship = new Friend
            {
                RequestorId = me,
                TargetId = target
            };
            db.Friends.Add(relationship);
            db.SaveChanges();

            return RedirectToAction("Detail");
        }
    }
}