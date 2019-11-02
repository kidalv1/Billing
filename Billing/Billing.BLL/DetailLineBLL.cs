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
      this.detailLineRepo.CreateDetailLine(detailLine);
    }

    public List<DetailLine> GetAll()
    {
      return detailLineRepo.GetAll();
    }
  }
}
