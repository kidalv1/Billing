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
    private DetailLineBLL _detailLineBLL;
    private VatBLL _vatBLL;
    private InvoiceBLL _invoiceBLL;
    public DetailLineController()
    {
      this._invoiceBLL = new InvoiceBLL();
      this._vatBLL = new VatBLL();
      this._detailLineBLL = new DetailLineBLL();
    }
        // GET: DetailLine
        public ActionResult Index()
        {
          
          return View(_detailLineBLL.GetAll());
        }
        public ActionResult Create(Invoice invoice)
        {
          try
          {
            Invoice i = _invoiceBLL.FindById(invoice.Id);
        if (i.Finished || !i.Active)
        {
          return RedirectToAction("index", "invoice");
        }
            ViewBag.invoiceId = i.Id;
            ViewBag.invoiceCode = i.InvoiceCode;
            ViewBag.Invoices = _invoiceBLL.GetNotFinishedInvoices();
            ViewBag.Vats = _vatBLL.GetVats();
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
      _detailLineBLL.CreateDetailLine(detailLine, idOfVat ,invoiceCode );
      
      
      return RedirectToAction("Details" , "Invoice", new{@id = idOfInvoice});
    }

    public ActionResult Details(int id)
    {
      DetailLine detailLine = _detailLineBLL.FindById(id);
      ViewBag.priceWithoutVAT = _detailLineBLL.GetPriceOfDetailLineWithoutVat(detailLine);
      ViewBag.priceWithVat = _detailLineBLL.GetPriceOfDetailLineWithVat(detailLine);
      return View(detailLine);
    }
    public ActionResult Edit(int id)
    {
      DetailLine detailLine = _detailLineBLL.FindById(id);
      return View(detailLine);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(DetailLine detailLine)
    {
      _detailLineBLL.EdtiDetailLine(detailLine);
      return RedirectToAction("Details", "Invoice", new { @id = _detailLineBLL.FindById(detailLine.Id).InvoiceId });

    }
    public ActionResult Delete(int id)
    {
      return View(_detailLineBLL.FindById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(DetailLine detailLine)
    {
      int invoiceId = _detailLineBLL.FindById(detailLine.Id).InvoiceId;
      _detailLineBLL.RemoveDetailLine(detailLine);
      return RedirectToAction("Details", "Invoice", new { @id = invoiceId });

    }
  }
}
