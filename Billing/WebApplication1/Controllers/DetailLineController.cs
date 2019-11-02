using Billing.BLL;
using DataContext.Exeptions;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
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
      ViewBag.Invoices = invoiceBLL.GetVisibilityInvoice();
      ViewBag.Vats = vatBLL.GetVats();

      return View();
    }

    [HttpPost]
    [ActionName("Create")]
    public ActionResult CreateDetailLine(DetailLine detailLine )
    {
      string idOfInvoice = Request.Form["Invoice"];
      string idOfVat = Request.Form["Vat"];
      try
      {
        detailLineBLL.CreateDetailLine(detailLine);
      }
      catch(AllFieldReaquiredExeption ex)
      {
        ViewBag.ex = ex.Message;
        return View();
      }
      
      return RedirectToAction("Index");
    }
  }
}
