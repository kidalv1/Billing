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
    VatRepo vatRepo;
    public VatBLL()
    {
      vatRepo = new VatRepo();
    }

    public List<Vat> GetVats()
    {
      return vatRepo.GetVats();
    }
  }
}
