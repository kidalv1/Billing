using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Models
{
  public class Customer
  {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public int Id { get; set; }
    public string Company { get; set; }
    public bool Visibility { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public Customer()
    {
      this.Visibility = true;
    }
  }
}
