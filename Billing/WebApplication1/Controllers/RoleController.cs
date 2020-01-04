using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  [Authorize(Roles = "Admin")]
  public class RoleController : Controller
    {
    private ApplicationDbContext _context;
    public RoleController()
    {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index()
    {
      var Roles = _context.Roles.ToList();
      return View(Roles);
    }

    // GET: Role
    public ActionResult Create()
        {
          IdentityRole role = new IdentityRole();
            return View(role);
        }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IdentityRole Role)
    {
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
      _context.Roles.Add(Role);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Delete(string id)
    {
      IdentityRole role = _context.Roles.Find(id);
       if(role.Name.ToLower() == "admin")
      {
        return RedirectToAction("index");
      }
      return View(role);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public ActionResult Delete(IdentityRole role)
    {
      
      _context.Entry(role).State = EntityState.Deleted;
      _context.Roles.Remove(role);
      _context.SaveChanges();
      return RedirectToAction("index");
    }


    public ActionResult Edit(string id)
    {
      IdentityRole role = _context.Roles.Find(id);
      if (role.Name.ToLower() == "admin")
      {
        return RedirectToAction("index");
      }
      return View(role);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Edit")]
    public ActionResult Edit(IdentityRole role)
    {
      IdentityRole newRole = _context.Roles.Find(role.Id);
      newRole.Name = role.Name;
        _context.SaveChanges();
         return RedirectToAction("index");
    }
  }
}
