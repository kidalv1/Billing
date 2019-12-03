using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      if (User.Identity.IsAuthenticated)
      {
        return RedirectToAction("Index", "Invoice");
      }
      else
      {
        return RedirectToAction("LogIn", "Account", new { area = "" });
      }

    }

  }
}
