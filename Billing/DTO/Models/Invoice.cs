using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
  public class Invoice
  {

    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    public string Reason { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int UserId { get; set; }
    public string User { get; set; }
    public string InvoiceCode { get; set; }
    public ICollection<DetailLine> DetailLines { get; set; }
    public Invoice()
    {
      this.Active = true;
    }
  }
}
