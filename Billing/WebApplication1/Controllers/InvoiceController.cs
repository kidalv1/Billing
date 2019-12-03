using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Billing.BLL;
using DataContext.Exeptions;
using DTO.Models;

namespace WebApplication1.Controllers
{
  [Authorize]
  public class InvoiceController : Controller
  {
    CustomerBLL customerBLL;
    InvoiceBLL invoiceBLL;
    public InvoiceController()
    {
      customerBLL = new CustomerBLL();
      invoiceBLL = new InvoiceBLL();
    }
    public ActionResult Index()
    {
      return View(invoiceBLL.GetVisibilityInvoice());
    } 
    public ActionResult Create()
    {
      ViewBag.cutomers = customerBLL.GetVisibilityCustomers();
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Create")]
    public ActionResult Create(Invoice invoice)
    {
      string idOfCustomer = Request.Form["customers"];
      invoiceBLL.AddInvoice(invoice, User.Identity.Name , int.Parse(idOfCustomer));
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {

      return View(invoiceBLL.FindById(id));
    }
    public ActionResult Details(int id)
    {
      Invoice invoice = invoiceBLL.FindById(id);
      ViewBag.invoice = invoice;
      ViewBag.priceWithoutVAT = invoiceBLL.GetTotalPrice(id);
      ViewBag.priceWithVat = invoiceBLL.GetTotalPriceWithVAT(id);
      ViewBag.pricesWithoutVat = invoiceBLL.GetPriceOfDatailLineOfInvoiceWithoutVat(id);
      ViewBag.prices = invoiceBLL.GetPriceOfDatailLineOfInvoiceWithVat(id);
      return View(invoice);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public ActionResult DeleteInvoice(int id)
    {
      
      if (invoiceBLL.FindById(id).DetailLines.Count > 0)
      {
        string reason = Request.Form["reason"];
        invoiceBLL.RemoveInvoice(id, reason);
      }
      else
      {
        invoiceBLL.RemoveInvoice(id);
      }
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Invoice invoice = invoiceBLL.FindById(id);
      if (invoice.Finished)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View(invoice);
      }
     }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Invoice invoice)
    {
      invoiceBLL.EditInvoice(invoice);
      return RedirectToAction("Index");
    }


  }
}
