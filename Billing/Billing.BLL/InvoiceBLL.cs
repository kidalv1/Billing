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
    private InvoiceRepo _invoiceRepo;
    private CustomerRepo _customerRepo;
    private DetailLineBLL _detailLineBLL;
    public InvoiceBLL()
    {
      _detailLineBLL = new DetailLineBLL();
      _customerRepo = new CustomerRepo();
      _invoiceRepo = new InvoiceRepo();
    }
    public void AddInvoice(Invoice invoice , string userName, int idOfCustomer)
    {
      int count = 0;
      try
      {
        Invoice lastInvoice = _invoiceRepo.GetLastInvoice();
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
      Customer customer = _customerRepo.FindById(idOfCustomer);
      invoice.CustomerId = customer.Id;
      _invoiceRepo.Add(invoice);
    }

    public Invoice findByInvoiceCode(string invoiceCode)
    {
      return _invoiceRepo.findByInvoiceCode(invoiceCode);
    }
    public List<Invoice> GetVisibilityInvoice()
    {
      return _invoiceRepo.GetVisibilityInvoice();
    }

    public List<Invoice> FindByNameOrEmail(string par)
    {
      List<Invoice> invoices = _invoiceRepo.FindByNameOrEmail(par);
      foreach (Invoice item in invoices)
      {
        item.Customer = _customerRepo.FindById(item.CustomerId);
      }

      return invoices;
    }
    public Invoice FindById(int id)
    {
      return _invoiceRepo.FindById(id);
    }
    public void RemoveInvoice(int id , string reason)
    {
      _invoiceRepo.RemoveInvoice(id, reason);
    }
    public double GetTotalPrice(int id)
    {
      Invoice invoice =  _invoiceRepo.FindById(id);
      double price = 0;
      foreach (var item in invoice.DetailLines)
      {
        price = price + _detailLineBLL.GetPriceOfDetailLineWithoutVat(item);
      }
      return price;
    }

    public double GetTotalPriceWithVAT(int id)
    {

      Invoice invoice = _invoiceRepo.FindById(id);
      double price = 0;
      foreach (var item in invoice.DetailLines)
      {
        price = price + _detailLineBLL.GetPriceOfDetailLineWithVat(item);
      }
      return price;
    }
    public void RemoveInvoice(int id)
    {
      _invoiceRepo.Remove(FindById(id));
    }
    public void EditInvoice(Invoice invoice)
    {
      _invoiceRepo.Edit(invoice);
    }
    public double[] GetPriceOfDatailLineOfInvoiceWithVat(int idOfInvoice)
    {
      Invoice invoice = _invoiceRepo.FindById(idOfInvoice);
      double[] prices = new double[invoice.DetailLines.Count];
      List<DetailLine> detailLines = invoice.DetailLines.ToList();
      for (int i = 0; i < invoice.DetailLines.Count; i++)
      {
        prices[i] = _detailLineBLL.GetPriceOfDetailLineWithVat(detailLines[i]);
      }
      return prices;
    }

    public double[] GetPriceOfDatailLineOfInvoiceWithoutVat(int idOfInvoice)
    {
      Invoice invoice = _invoiceRepo.FindById(idOfInvoice);
      double[] prices = new double[invoice.DetailLines.Count];
      List<DetailLine> detailLines = invoice.DetailLines.ToList();
      for (int i = 0; i < invoice.DetailLines.Count; i++)
      {
        prices[i] = _detailLineBLL.GetPriceOfDetailLineWithoutVat(detailLines[i]);
      }
      return prices;
    }
    public List<Invoice> GetNotFinishedInvoices()
    {
      return _invoiceRepo.GetNotFinishedInvoices();
    }


  }
}
