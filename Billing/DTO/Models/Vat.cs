using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
  public class Vat
  {
    public int Id { get; set; }
    public int Percentage { get; set; }
    public ICollection<DetailLine> DetailLines { get; set; }
    public Vat()
    {

    }
  }
}
