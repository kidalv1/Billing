using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext.Repositories;
using DTO.Models;

namespace Billing.BLL
{
  class InvoiceBLL
  {
    InvoiceRepo invoiceRepo;
    public InvoiceBLL()
    {
      invoiceRepo = new InvoiceRepo();
    }
    public void AddInvoice(Invoice invoice)
    {
      invoiceRepo.AddInvoice(invoice);
    }

  }
}
