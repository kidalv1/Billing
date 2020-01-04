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
        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: User


        public ActionResult Edit(string id)
        { 
          return View(_context.Users.Find(User.Identity.GetUserId()));
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
          _context.Entry(user).State = EntityState.Modified;
          _context.SaveChanges();
          return RedirectToAction("Detail");
        }

        public ActionResult Detail()
        {
          return View(_context.Users.Find(User.Identity.GetUserId()));
        }
    }
}
