using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
  public class DetailLine
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Item { get; set; }
    [Required]
    public double PricePiece { get; set; }
    [Required]
    public double Discount { get; set; }
    [Required]
    public int CountOfItems { get; set; }
    public int VatId { get; set; }
    [Required]
    public Vat Vat { get; set; }
    public DetailLine()
    {

    }
  }
}
