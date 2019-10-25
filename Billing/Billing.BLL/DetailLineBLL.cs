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
    public DetailLineBLL()
    {
      detailLineRepo = new DetailLineRepo();
    }

    public void CreateDetailLine(DetailLine detailLine)
    {
      this.detailLineRepo.CreateDetailLine(detailLine);
    }

    public List<DetailLine> GetAll()
    {
      return detailLineRepo.GetAll();
    }
  }
}
