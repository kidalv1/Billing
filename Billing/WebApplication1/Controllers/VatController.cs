using Billing.BLL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class VatController : Controller
    {
        VatBLL vatBll;
        public VatController()
        {
          vatBll = new VatBLL();
        }
        // GET: Vat
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vat vat)
        {
          vatBll.Create(vat);
          return RedirectToAction("Index", "Invoice");
        }
    }
}
