using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Billing.BLL;
using DTO.Models;

namespace WebApplication1.Controllers
{
  public class CustomerController : Controller
    {
    BLL bll;
    public CustomerController()
    {
      bll = new BLL();
    }
        // GET: Custumer
        public ActionResult Index()
        {
            return View();
        }
    public ActionResult CreateCustomer()
    {

      return View();
    }
    [HttpPost]
    public ActionResult CreateCustomer(Customer customer)
    {

      bll.AddCustomer(customer);
      return RedirectToAction("Index");
    }
  }
}
