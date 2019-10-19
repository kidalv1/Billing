using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Billing.BLL;
using DTO.Models;

namespace WebApplication1.Controllers
{
  public class InvoiceController : Controller
  {
    CustomerBLL invoiceBLL;
    public InvoiceController()
    {
      invoiceBLL = new CustomerBLL();
    }
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [ActionName("Create")]
    public ActionResult CreateInvoice(Invoice invoice)
    {
      return RedirectToAction("Index");
    }
  }
}
