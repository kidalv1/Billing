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
        public ActionResult Create()
    {
      ViewBag.Invoices = invoiceBLL.GetNotFinishedInvoices();
      ViewBag.Vats = vatBLL.GetVats();

      return View();
    }

    [HttpPost]
    [ActionName("Create")]
    public ActionResult CreateDetailLine(DetailLine detailLine )
    {
      int idOfInvoice = int.Parse(Request.Form["Invoice"]);
      int idOfVat = int.Parse(Request.Form["Vat"]);
        detailLineBLL.CreateDetailLine(detailLine, idOfVat , idOfInvoice);
      
      
      return RedirectToAction("Index");
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
      return RedirectToAction("index");
    }
    public ActionResult Delete(int id)
    {
      return View(detailLineBLL.FindById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(DetailLine detailLine)
    {
      detailLineBLL.RemoveDetailLine(detailLine);
      return RedirectToAction("Index");
    }
  }
}
