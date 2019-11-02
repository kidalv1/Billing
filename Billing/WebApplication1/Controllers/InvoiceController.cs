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
    [ActionName("Create")]
    public ActionResult CreateInvoice(Invoice invoice)
    {
      string idOfCustomer = Request.Form["customers"];
      
      try
      {
        invoiceBLL.AddInvoice(invoice, User.Identity.Name , int.Parse(idOfCustomer));
      }
      catch(NotExistExeption ex)
      {
        ViewBag.ex = ex.Message;
        return View();
      }
      
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
      return View(invoice);
    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult DeleteInvoice(int id)
    {
      
      if (invoiceBLL.FindById(id).DetailLines.Count >0)
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
    [HttpGet]
    public ActionResult Edit(int id)
    {
      return View(invoiceBLL.FindById(id));
    }
    [HttpPost]
    public ActionResult Edit(Invoice invoice)
    {
      invoiceBLL.EditInvoice(invoice);
      return RedirectToAction("Index");
    }


  }
}
