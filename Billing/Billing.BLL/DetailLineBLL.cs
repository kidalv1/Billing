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
    private DetailLineRepo _detailLineRepo;
    private InvoiceRepo invoiceRepo;
    private VatRepo _vatRepo;
    public DetailLineBLL()
    {
      _vatRepo = new VatRepo();
      invoiceRepo = new InvoiceRepo();
      _detailLineRepo = new DetailLineRepo();
    }

    public void CreateDetailLine(DetailLine detailLine , int idOfVat , string invoiceCode)
    {
      Invoice invoice = invoiceRepo.findByInvoiceCode(invoiceCode);
      detailLine.InvoiceId = invoice.Id;
      detailLine.VatId = idOfVat;
      this._detailLineRepo.Add(detailLine);
    }

    public List<DetailLine> GetAll()
    {
      return _detailLineRepo.GetAll();
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
      DetailLine detailLine = _detailLineRepo.FindById(id);
      detailLine.Vat = _vatRepo.FindById(detailLine.VatId);


      return detailLine;
    }

    public void RemoveDetailLine(DetailLine detailLine)
    {

      _detailLineRepo.Remove(FindById(detailLine.Id));
    }

    public void EdtiDetailLine(DetailLine detailLine)
    {
      _detailLineRepo.Edit(detailLine);
    }
  }
}
