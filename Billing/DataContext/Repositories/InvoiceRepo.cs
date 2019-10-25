using DataContext.Exeptions;
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
    public List<Invoice> GetVisibilityInvoice()
    {
      IEnumerable<Invoice> invoices =
             from i in data.Invoices.ToList()
             where i.Active
             select i;

      return invoices.ToList();
    }

    public Invoice FindById(int id)
    {
      Invoice invoice = data.Invoices.Find(id);
      if (invoice.Finished)
      {
        throw new NotExistExeption();
      }
      IEnumerable<DetailLine> detailLines =
             from d in data.DetailLines.ToList()
             where d.InvoiceId == id
             select d;

      foreach (DetailLine item in detailLines)
      {
        item.Vat = data.Vats.Find(item.VatId);
      }
      invoice.DetailLines = detailLines.ToList();
      return invoice;
    }
    public void RemoveInvoice(int id)
    {
      data.Invoices.Remove(FindById(id));
      data.SaveChanges();
    }
    public void RemoveInvoice(int id , string reason)
    {
      Invoice invoice = FindById(id);
      invoice.Active = false;
      invoice.Reason = reason;
      data.SaveChanges();
    }


    public void EdtiInvoice(Invoice invoice)
    {
      Invoice oldInvoice = FindById(invoice.Id);
      oldInvoice.Finished = invoice.Finished;
      data.SaveChanges();
    }
    public Invoice GetLastInvoice()
    {
      
      return data.Invoices.OrderByDescending(i => i.Id).First();


    }
  }

  
}
