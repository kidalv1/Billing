using DataContext.Exeptions;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class CustomerRepo : ICRUD<Customer>
  {
    private Data data = new Data();
    public void Add(Customer customer)
    {
      data.Customers.Add(customer);
      data.SaveChanges();
    }
    public Customer FindById(int id)
    {
      Customer customer = null;
         customer = data.Customers.Find(id);
        if (!customer.Visibility)
        {
          throw new NotExistExeption();
        }
      
      
      return customer;
    }
    public void Remove(Customer customer)
    {
      customer.Visibility = false;
      data.SaveChanges();
    }
    public List<Customer> GetVisibilityCustomers()
    {
      IEnumerable<Customer> customers =
            from c in data.Customers.ToList()
            where c.Visibility
            select c;

      return customers.ToList();
    }
    public void Edit(Customer customer)
    {
      Customer oldCustomer = FindById(customer.Id);
      oldCustomer.Firstname = customer.Firstname;
      oldCustomer.Lastname = customer.Lastname;
      oldCustomer.Email = customer.Email;
      oldCustomer.Company = customer.Company;

      data.SaveChanges();
    }



    public List<Customer> GetAll()
    {
      return data.Customers.ToList();
    }

  }
}
