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
    private CustomerBLL _customerBLL;
    private InvoiceBLL _invoiceBLL;
    public InvoiceController()
    {
      _customerBLL = new CustomerBLL();
      _invoiceBLL = new InvoiceBLL();
    }
    public ActionResult Index(string search)
    {

      if (!String.IsNullOrEmpty(search))
      {
        return View(_invoiceBLL.FindByNameOrEmail(search));
      }
      
        return View(_invoiceBLL.GetVisibilityInvoice());
      

      
    }
    public ActionResult Create()
    {
      ViewBag.cutomers = _customerBLL.GetVisibilityCustomers();
      return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //[ActionName("Index")]
    //public ActionResult IndexSearch(string save)
    //{
    //  return View();
    //}
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Create")]
    public ActionResult Create(Invoice invoice)
    {
      string idOfCustomer = Request.Form["customers"];
      _invoiceBLL.AddInvoice(invoice, User.Identity.Name , int.Parse(idOfCustomer));
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      ViewBag.priceWithoutVAT = _invoiceBLL.GetTotalPrice(id);
      ViewBag.priceWithVat = _invoiceBLL.GetTotalPriceWithVAT(id);
      return View(_invoiceBLL.FindById(id));
    }
    public ActionResult Details(int id)
    {
      Invoice invoice = _invoiceBLL.FindById(id);
      ViewBag.invoice = invoice;
      ViewBag.priceWithoutVAT = _invoiceBLL.GetTotalPrice(id);
      ViewBag.priceWithVat = _invoiceBLL.GetTotalPriceWithVAT(id);
      ViewBag.pricesWithoutVat = _invoiceBLL.GetPriceOfDatailLineOfInvoiceWithoutVat(id);
      ViewBag.prices = _invoiceBLL.GetPriceOfDatailLineOfInvoiceWithVat(id);
      return View(invoice);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public ActionResult DeleteInvoice(int id)
    {
      
      if (_invoiceBLL.FindById(id).DetailLines.Count > 0)
      {
        string reason = Request.Form["reason"];
        _invoiceBLL.RemoveInvoice(id, reason);
      }
      else
      {
        _invoiceBLL.RemoveInvoice(id);
      }
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Invoice invoice = _invoiceBLL.FindById(id);
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
      _invoiceBLL.EditInvoice(invoice);
      return RedirectToAction("Index");
    }

    
  }
  
}
