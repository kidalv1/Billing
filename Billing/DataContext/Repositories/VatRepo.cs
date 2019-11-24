using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class VatRepo : ICRUD<Vat>
  {
    private Data data = new Data();

    public void Add(Vat t)
    {
      throw new NotImplementedException();
    }

    public void Edit(Vat t)
    {
      throw new NotImplementedException();
    }

    public Vat FindById(int id)
    {
      return data.Vats.Find(id);
    }
    public List<Vat> GetAll()
    {
     return data.Vats.ToList();
    }

    public void Remove(Vat t)
    {
      throw new NotImplementedException();
    }
  }
}
