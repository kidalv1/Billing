using DataContext.Exeptions;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public class DetailLineRepo : ICRUD<DetailLine>
  {
    private Data data = new Data();
    public void Add(DetailLine detailLine)
    {

        this.data.DetailLines.Add(detailLine);
        data.SaveChanges();
      

      
      
    }

    public List<DetailLine> GetAll()
    {
      foreach (DetailLine item in data.DetailLines.ToList())
      {
        item.Vat = data.Vats.Find(item.VatId);
      }
      return data.DetailLines.ToList();
    }

    public DetailLine FindById(int id)
    {
      return data.DetailLines.Find(id);
    }

    public void Remove(DetailLine detailLine)
    {
      data.DetailLines.Remove(detailLine);
      data.SaveChanges();
    }
    public void Edit(DetailLine detailLine)
    {
      DetailLine newDetailLine = FindById(detailLine.Id);
      newDetailLine.Item = detailLine.Item;
      newDetailLine.PricePiece = detailLine.PricePiece;
      newDetailLine.CountOfItems = detailLine.CountOfItems;
      newDetailLine.Discount = detailLine.Discount;
      data.SaveChanges();
    }

  }
}
