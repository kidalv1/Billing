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
    public InvoiceBLL()
    {
      CustomerRepo = new CustomerRepo();
      invoiceRepo = new InvoiceRepo();
    }
    public void AddInvoice(Invoice invoice , string userName, int idOfCustomer)
    {
      Invoice lastInvoice = invoiceRepo.GetLastInvoice();
      string[] lastInvoiceCode = lastInvoice.InvoiceCode.Split('-');
      int count = int.Parse(lastInvoiceCode[1]);
      count++;
      if (DateTime.Today.Month != mouth)
      {
        mouth = DateTime.Today.Month;
      }

      invoice.User = userName;
      invoice.Date = DateTime.Now;
      string invoiceCode = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() +  "-" + count.ToString("0000");
      invoice.InvoiceCode = invoiceCode;
      Customer customer = CustomerRepo.FindById(idOfCustomer);
      invoice.CustomerId = customer.Id;
      invoiceRepo.AddInvoice(invoice);
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
        double priceWithoutDisc = double.Parse(item.PricePiece.ToString()) * double.Parse(item.CountOfItems.ToString());
        double disc = (priceWithoutDisc / 100 * double.Parse(item.Discount.ToString()));
        price = price + (priceWithoutDisc - disc);
      }
      return price;
    }

    public double GetTotalPriceWithVAT(int id)
    {

      Invoice invoice = invoiceRepo.FindById(id);
      double price = 0;
      foreach (var item in invoice.DetailLines)
      {
        double priceWithoutDisc = double.Parse(item.PricePiece.ToString()) * double.Parse(item.CountOfItems.ToString());
        double disc = (priceWithoutDisc / 100 * double.Parse(item.Discount.ToString()));
        double priceWithDisc = priceWithoutDisc - disc;
        double vat = priceWithDisc / 100 * item.Vat.Percentage;
        price = price + priceWithDisc + vat;
        price = Math.Round(price, 2);
      }
      return price;
    }
    public void RemoveInvoice(int id)
    {
      invoiceRepo.RemoveInvoice(id);
    }
    public void EditInvoice(Invoice invoice)
    {
      invoiceRepo.EdtiInvoice(invoice);
    }
  }
}
