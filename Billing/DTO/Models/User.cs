
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
  public class User : Person
  {
    public int Id { get; set; }
    public string Password { get; set; }
    public string Resettoken { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public User()
    {
    }
  }
}
