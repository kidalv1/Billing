using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class VatRepo
  {
    private Data data = new Data();
    public Vat GetVat(int id)
    {
      return data.Vats.Find(id);
    }
    public List<Vat> GetVats()
    {
     return data.Vats.ToList();
    }
  }
}
