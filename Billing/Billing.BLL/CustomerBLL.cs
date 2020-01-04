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
    private CustomerRepo _customerRepo;
    public CustomerBLL()
    {
      _customerRepo = new CustomerRepo();
    }
    public void AddCustomer(Customer customer)
    {
      _customerRepo.Add(customer);
    }

    public List<Customer> GetVisibilityCustomers()
    {
      return _customerRepo.GetVisibilityCustomers();
    }
    public Customer FindById(int id)
    {
      return _customerRepo.FindById(id);
    }
    public void RemoveCustomer(Customer customer)
    {
      _customerRepo.Remove(customer);
    }

    public void EditCustomer(Customer customer)
    {
      _customerRepo.Edit(customer);
    }

    }
}
