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
    public class BLL
    {
    CustumerRepo customerRepo;
    public BLL()
    {
      customerRepo = new CustumerRepo();
    }
    public void AddCustomer(Customer customer)
    {
      customerRepo.AddCutomer(customer);
    }

    }
}
