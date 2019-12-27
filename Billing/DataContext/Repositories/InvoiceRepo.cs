using DataContext.Exeptions;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class InvoiceRepo : ICRUD<Invoice>
  {

    private Data data = new Data();
    public void Add(Invoice invoice)
    {
      data.Invoices.Add(invoice);
      data.SaveChanges();
    }

    public List<Invoice> FindByNameOrEmail(string par)
    {
      SqlParameter param = new SqlParameter("@p", SqlDbType.VarChar);
      param.Value = "%" + par +"%";
      return  data.Invoices.SqlQuery("select * from Invoice as i " +
                                                      "where exists" +
                                                      "(select CustomerId from Customer as s" +
                                                      " where (Firstname like @p or Lastname like @p or Email like @p) " +
                                                      "and s.ID = i.CustomerId)",param).ToList();
    }
    public List<Invoice> GetVisibilityInvoice()
    {
      IEnumerable<Invoice> invoices =
             from i in data.Invoices.ToList()
             orderby i.Date descending , i.InvoiceCode descending 
             where i.Active
             select i;

      foreach (Invoice item in invoices)
      {
        item.Customer = data.Customers.Find(item.CustomerId);
      }
      return invoices.ToList();
    }
    public List<Invoice> GetNotFinishedInvoices()
    {
      IEnumerable<Invoice> invoices =
             from i in data.Invoices.ToList()
             where !i.Finished
             select i;

      return invoices.ToList();
    }

    public Invoice findByInvoiceCode(string invoiceCode)
    {
      IEnumerable<Invoice> invoices =
        from i in data.Invoices.ToList()
        where i.InvoiceCode == invoiceCode
        select i;

      return invoices.First();
    }
    public Invoice FindById(int id)
    {
      Invoice invoice = data.Invoices.Find(id);
      IEnumerable<DetailLine> detailLines =
             from d in data.DetailLines.ToList()
             where d.InvoiceId == id
             select d;

      foreach (DetailLine item in detailLines)
      {
        item.Vat = data.Vats.Find(item.VatId);
      }
      invoice.Customer = data.Customers.Find(invoice.CustomerId);
      invoice.DetailLines = detailLines.ToList();
      return invoice;
    }
    public void Remove(Invoice invoice)
    {
      data.Invoices.Remove(invoice);
      data.SaveChanges();
    }
    public void RemoveInvoice(int id , string reason)
    {
      Invoice invoice = FindById(id);
      invoice.Active = false;
      invoice.Reason = reason;
      data.SaveChanges();
    }


    public void Edit(Invoice invoice)
    {
      Invoice newInvoice = FindById(invoice.Id);
      newInvoice.Finished = invoice.Finished;
      data.SaveChanges();
    }
    public Invoice GetLastInvoice()
    {
      Invoice invoice = null;
      try
      {
         invoice = data.Invoices.OrderByDescending(i => i.Id).First();
      }
      catch
      {

      }
      return invoice;

    }

    public List<Invoice> GetAll()
    {
      return data.Invoices.ToList();
    }


  }

  
}
