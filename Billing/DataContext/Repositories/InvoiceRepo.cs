using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class InvoiceRepo
  {
    private Data data = new Data();
    public void AddInvoice(Invoice invoice)
    {
      data.Invoices.Add(invoice);
      data.SaveChanges();
    }
  }

  
}
