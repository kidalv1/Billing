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
    public string Item { get; set; }
    public decimal PricePiece { get; set; }
    public decimal Discount { get; set; }
    public int CountOfItems { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public int VatId { get; set; }
    public Vat Vat { get; set; }
    public DetailLine()
    {

    }
  }
}
