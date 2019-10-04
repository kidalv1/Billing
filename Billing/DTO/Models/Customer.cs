using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Models
{
  public class Customer: Person
  {
    public int Id { get; set; }
    [Required]
    public string Company { get; set; }
    public bool Visibility { get; set; }
    public Customer()
    {
      this.Visibility = true;
    }
  }
}
