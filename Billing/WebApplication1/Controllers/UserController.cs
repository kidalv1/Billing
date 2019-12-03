using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext context;
        public UserController()
        {
            context = new ApplicationDbContext();
        }
        // GET: User


        public ActionResult Edit(string id)
        { 
          return View(context.Users.Find(User.Identity.GetUserId()));
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
          context.Entry(user).State = EntityState.Modified;
          context.SaveChanges();
          return RedirectToAction("Detail");
        }

        public ActionResult Detail()
        {
          return View(context.Users.Find(User.Identity.GetUserId()));
        }
    }
}
