using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Billing.BLL;
using DTO.Models;

namespace WebApplication1.Controllers
{
  [Authorize]
  public class CustomerController : Controller
    {
    CustomerBLL customerBLL;
    public CustomerController()
    {
      customerBLL = new CustomerBLL();
    }
        // GET: Custumer
        public ActionResult Index()
        {
      
            return View(customerBLL.GetVisibilityCustomers());
        }
    public ActionResult CreateCustomer()
    {

      return View();
    }
    [HttpPost]
    public ActionResult CreateCustomer(Customer customer)
    {

      customerBLL.AddCustomer(customer);
      return RedirectToAction("Index");
    }

    public ActionResult Detail(int id)
    {
      return View(customerBLL.FindById(id));
    }
    public ActionResult Delete(int id)
    {
      return View(customerBLL.FindById(id));
    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult DeleteCostumer(int id)
    {
      customerBLL.RemoveCustomer(customerBLL.FindById(id));
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      return View(customerBLL.FindById(id));
    }
    [HttpPost]
    public ActionResult Edit(Customer customer)
    {
      customerBLL.EditCustomer(customer);
      return RedirectToAction("Index");
    }
  }
}
