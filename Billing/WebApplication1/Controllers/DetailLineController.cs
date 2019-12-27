using Billing.BLL;
using DataContext.Exeptions;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  [Authorize]
  public class DetailLineController : Controller
    {
    DetailLineBLL detailLineBLL;
    VatBLL vatBLL;
    InvoiceBLL invoiceBLL;
    public DetailLineController()
    {
      this.invoiceBLL = new InvoiceBLL();
      this.vatBLL = new VatBLL();
      this.detailLineBLL = new DetailLineBLL();
    }
        // GET: DetailLine
        public ActionResult Index()
        {
          
          return View(detailLineBLL.GetAll());
        }
        public ActionResult Create(Invoice invoice)
        {
          try
          {
            Invoice i = invoiceBLL.FindById(invoice.Id);
            ViewBag.invoiceId = i.Id;
            ViewBag.invoiceCode = i.InvoiceCode;
            ViewBag.Invoices = invoiceBLL.GetNotFinishedInvoices();
            ViewBag.Vats = vatBLL.GetVats();
          }
          catch
          {
            RedirectToAction("Index", "Invoice");
          }
          
          return View();
        }


    [HttpPost]
    [ActionName("Create")]
    public ActionResult CreateDetailLine(DetailLine detailLine )
    {
      int idOfInvoice = detailLine.Id;
      string invoiceCode = Request.Form["Invoice"];
      int idOfVat = int.Parse(Request.Form["Vat"]);
      detailLineBLL.CreateDetailLine(detailLine, idOfVat ,invoiceCode );
      
      
      return RedirectToAction("Details" , "Invoice", new{@id = idOfInvoice});
    }

    public ActionResult Details(int id)
    {
      DetailLine detailLine = detailLineBLL.FindById(id);
      ViewBag.priceWithoutVAT = detailLineBLL.GetPriceOfDetailLineWithoutVat(detailLine);
      ViewBag.priceWithVat = detailLineBLL.GetPriceOfDetailLineWithVat(detailLine);
      return View(detailLine);
    }
    public ActionResult Edit(int id)
    {
      DetailLine detailLine = detailLineBLL.FindById(id);
      return View(detailLine);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(DetailLine detailLine)
    {
      detailLineBLL.EdtiDetailLine(detailLine);
      return RedirectToAction("Details", "Invoice", new { @id = detailLineBLL.FindById(detailLine.Id).InvoiceId });

    }
    public ActionResult Delete(int id)
    {
      return View(detailLineBLL.FindById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(DetailLine detailLine)
    {
      int invoiceId = detailLineBLL.FindById(detailLine.Id).InvoiceId;
      detailLineBLL.RemoveDetailLine(detailLine);
      return RedirectToAction("Details", "Invoice", new { @id = invoiceId });

    }
  }
}
