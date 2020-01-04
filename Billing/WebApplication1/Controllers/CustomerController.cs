using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Billing.BLL;
using DTO.Models;

namespace WebApplication1.Controllers
{
  [Authorize]
  public class CustomerController : Controller
    {
    private CustomerBLL _customerBLL;
    public CustomerController()
    {
      _customerBLL = new CustomerBLL();
    }
        // GET: Custumer
        public ActionResult Index()
        {
      
            return View(_customerBLL.GetVisibilityCustomers());
        }
    public ActionResult CreateCustomer()
    {

      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateCustomer(Customer customer)
    {

      _customerBLL.AddCustomer(customer);
      return RedirectToAction("Index");
    }

    public ActionResult Detail(int id)
    {
      return View(_customerBLL.FindById(id));
    }
    public ActionResult Delete(int id)
    {
      return View(_customerBLL.FindById(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public ActionResult DeleteCostumer(int id)
    {
      _customerBLL.RemoveCustomer(_customerBLL.FindById(id));
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      return View(_customerBLL.FindById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Customer customer)
    {
      _customerBLL.EditCustomer(customer);
      return RedirectToAction("Index");
    }
  }
}
