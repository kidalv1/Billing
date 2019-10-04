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
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    public string Reason { get; set; }
    public int CustomerId { get; set; }
    [Required]
    public Customer Customer { get; set; }
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }
    public int DatailLineId { get; set; }
    public DetailLine DitailLine { get; set; }
    public Invoice()
    {
      this.Active = true;
    }
  }
}
