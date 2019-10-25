using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing;
using DataContext.Repositories;
using DTO.Models;

namespace Billing.BLL
{
    public class CustomerBLL
    {
    CustomerRepo customerRepo;
    public CustomerBLL()
    {
      customerRepo = new CustomerRepo();
    }
    public void AddCustomer(Customer customer)
    {
      customerRepo.AddCutomer(customer);
    }

    public List<Customer> GetVisibilityCustomers()
    {
      return customerRepo.GetVisibilityCustomers();
    }
    public Customer FindById(int id)
    {
      return customerRepo.FindById(id);
    }
    public void RemoveCustomer(Customer customer)
    {
      customerRepo.removeCustomer(customer);
    }

    public void EditCustomer(Customer customer)
    {
      customerRepo.EditCustomer(customer);
    }

    }
}
