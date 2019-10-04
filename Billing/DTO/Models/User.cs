
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
    [Key]
    public int Id { get; set; }
    [Required]
    public string Password { get; set; }
    public string Resettoken { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public User()
    {
      this.UserRoles = new List<UserRole>();
    }
  }
}
