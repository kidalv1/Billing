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
    public DetailLineController()
    {
      this.detailLineBLL = new DetailLineBLL();
    }
        // GET: DetailLine
        public ActionResult Index()
        {
      return View(detailLineBLL.GetAll());
        }
        public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ActionName("Create")]
    public ActionResult CreateDetailLine(DetailLine detailLine )
    {
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
