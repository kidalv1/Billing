using DataContext.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.BLL
{
  public class DetailLineBLL
  {
    DetailLineRepo detailLineRepo;
    InvoiceRepo invoiceRepo;
    VatRepo vatRepo;
    public DetailLineBLL()
    {
      vatRepo = new VatRepo();
      invoiceRepo = new InvoiceRepo();
      detailLineRepo = new DetailLineRepo();
    }

    public void CreateDetailLine(DetailLine detailLine , int idOfVat , int idOfInvoice)
    {
      detailLine.InvoiceId = idOfInvoice;
      detailLine.VatId = idOfVat;
      this.detailLineRepo.Add(detailLine);
    }

    public List<DetailLine> GetAll()
    {
      return detailLineRepo.GetAll();
    }

    public double GetPriceOfDetailLineWithVat(DetailLine detailLine)
    {
      double price = 0;
      double priceWithoutDisc = double.Parse(detailLine.PricePiece.ToString()) * double.Parse(detailLine.CountOfItems.ToString());
      double disc = (priceWithoutDisc / 100 * double.Parse(detailLine.Discount.ToString()));
      double priceWithDisc = priceWithoutDisc - disc;
      double vat = priceWithDisc / 100 * detailLine.Vat.Percentage;
      price = priceWithDisc + vat;
      price = Math.Round(price, 2);
      return price;
    }

    public double GetPriceOfDetailLineWithoutVat(DetailLine detailLine)
    {
      double price = 0;
      double priceWithoutDisc = double.Parse(detailLine.PricePiece.ToString()) * double.Parse(detailLine.CountOfItems.ToString());
      double disc = (priceWithoutDisc / 100 * double.Parse(detailLine.Discount.ToString()));
      price =  (priceWithoutDisc - disc);
      return price;
    }

    public DetailLine FindById(int id)
    {
      DetailLine detailLine = detailLineRepo.FindById(id);
      detailLine.Vat = vatRepo.FindById(detailLine.VatId);
      return detailLine;
    }

    public void RemoveDetailLine(DetailLine detailLine)
    {
      detailLineRepo.Remove(detailLine);
    }

    public void EdtiDetailLine(DetailLine detailLine)
    {
      detailLineRepo.Edit(detailLine);
    }
  }
}
