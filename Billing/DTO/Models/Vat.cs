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
    [Key]
    public int Id { get; set; }
    [Required]
    public double Percentage { get; set; }
    public Vat()
    {

    }
  }
}
