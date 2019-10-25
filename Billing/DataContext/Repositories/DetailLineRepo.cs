using DataContext.Exeptions;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class DetailLineRepo
  {
    private Data data = new Data();
    public void CreateDetailLine(DetailLine detailLine)
    {
      try
      {
        this.data.DetailLines.Add(detailLine);
        data.SaveChanges();
      }
      catch(Exception ex)
      {
        throw new AllFieldReaquiredExeption();
      }
      
      
    }

    public List<DetailLine> GetAll()
    {
      foreach (DetailLine item in data.DetailLines.ToList())
      {
        item.Vat = data.Vats.Find(item.VatId);
      }
      return data.DetailLines.ToList();
    }
  }
}
