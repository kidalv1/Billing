using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Billing.BLL;

namespace WebApplication1.Controllers
{
  public class InvoiceController : Controller
  {
    public InvoiceController()
    {
      BLL bl = new BLL();
    }
    public ActionResult Index()
    {
      return View();
    }
  }
}
