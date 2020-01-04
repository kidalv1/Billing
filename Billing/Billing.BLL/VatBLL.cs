using DataContext.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.BLL
{
  public class VatBLL
  {
    private VatRepo _vatRepo;
    public VatBLL()
    {
      _vatRepo = new VatRepo();
    }

    public void Create(Vat vat)
    {
      _vatRepo.Add(vat);
    }
    public List<Vat> GetVats()
    {
      return _vatRepo.GetAll();
    }
  }
}
