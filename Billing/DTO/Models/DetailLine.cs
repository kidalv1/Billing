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
    public int Id { get; set; }
    [Required]
    public string Item { get; set; }
    [Required]
    public decimal PricePiece { get; set; }
    [Required]
    public decimal Discount { get; set; }
    [Required]
    public int CountOfItems { get; set; }
    [Required]
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    [Required]
    public int VatId { get; set; }
    public Vat Vat { get; set; }
    public DetailLine()
    {

    }

    public int GetVatPercantage()
    {
      return this.Vat.Percentage;
    }

    
  }
}
