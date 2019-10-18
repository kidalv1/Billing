using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class CustumerRepo
  {
    private Data data = new Data();
    public void AddCutomer(Customer customer)
    {
      data.Customers.Add(customer);
      data.SaveChanges();
    }
    public void addUser(Customer user)
    {
      data.Customers.Add(user);
      data.SaveChanges();
    }
    public Customer findUser(int id)
    {
      return data.Customers.Find(id);
    }
    public void removeUser(Customer user)
    {
      data.Customers.Remove(user);
    }
  }
}
