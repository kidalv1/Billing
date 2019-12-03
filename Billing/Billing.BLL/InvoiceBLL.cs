using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext.Repositories;
using DTO.Models;

namespace Billing.BLL
{
  public class InvoiceBLL
  {
    static private int mouth = 0;
    InvoiceRepo invoiceRepo;
    CustomerRepo CustomerRepo;
    DetailLineBLL DetailLineBLL;
    public InvoiceBLL()
    {
      DetailLineBLL = new DetailLineBLL();
      CustomerRepo = new CustomerRepo();
      invoiceRepo = new InvoiceRepo();
    }
    public void AddInvoice(Invoice invoice , string userName, int idOfCustomer)
    {
      int count = 0;
      try
      {
        Invoice lastInvoice = invoiceRepo.GetLastInvoice();
        string[] lastInvoiceCode = lastInvoice.InvoiceCode.Split('-');
        count = int.Parse(lastInvoiceCode[1]);
        count++;
        if (lastInvoice.Date.Month != DateTime.Now.Month)
        {
          count = 1;
        }
      }
      catch
      {
        count = 1;
      }
      invoice.User = userName;
      invoice.Date = DateTime.Now;
      string invoiceCode = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() +  "-" + count.ToString("0000");
      invoice.InvoiceCode = invoiceCode;
      Customer customer = CustomerRepo.FindById(idOfCustomer);
      invoice.CustomerId = customer.Id;
      invoiceRepo.Add(invoice);
    }
    public List<Invoice> GetVisibilityInvoice()
    {
      return invoiceRepo.GetVisibilityInvoice();
    }
    public Invoice FindById(int id)
    {
      return invoiceRepo.FindById(id);
    }
    public void RemoveInvoice(int id , string reason)
    {
      invoiceRepo.RemoveInvoice(id, reason);
    }
    public double GetTotalPrice(int id)
    {
      Invoice invoice =  invoiceRepo.FindById(id);
      double price = 0;
      foreach (var item in invoice.DetailLines)
      {
        price = price + DetailLineBLL.GetPriceOfDetailLineWithoutVat(item);
      }
      return price;
    }

    public double GetTotalPriceWithVAT(int id)
    {

      Invoice invoice = invoiceRepo.FindById(id);
      double price = 0;
      foreach (var item in invoice.DetailLines)
      {
        price = price + DetailLineBLL.GetPriceOfDetailLineWithVat(item);
      }
      return price;
    }
    public void RemoveInvoice(int id)
    {
      invoiceRepo.Remove(FindById(id));
    }
    public void EditInvoice(Invoice invoice)
    {
      invoiceRepo.Edit(invoice);
    }
    public double[] GetPriceOfDatailLineOfInvoiceWithVat(int idOfInvoice)
    {
      Invoice invoice = invoiceRepo.FindById(idOfInvoice);
      double[] prices = new double[invoice.DetailLines.Count];
      List<DetailLine> detailLines = invoice.DetailLines.ToList();
      for (int i = 0; i < invoice.DetailLines.Count; i++)
      {
        prices[i] = DetailLineBLL.GetPriceOfDetailLineWithVat(detailLines[i]);
      }
      return prices;
    }

    public double[] GetPriceOfDatailLineOfInvoiceWithoutVat(int idOfInvoice)
    {
      Invoice invoice = invoiceRepo.FindById(idOfInvoice);
      double[] prices = new double[invoice.DetailLines.Count];
      List<DetailLine> detailLines = invoice.DetailLines.ToList();
      for (int i = 0; i < invoice.DetailLines.Count; i++)
      {
        prices[i] = DetailLineBLL.GetPriceOfDetailLineWithoutVat(detailLines[i]);
      }
      return prices;
    }
    public List<Invoice> GetNotFinishedInvoices()
    {
      return invoiceRepo.GetNotFinishedInvoices();
    }


  }
}
