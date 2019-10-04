using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
  public class Role
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string NameRole { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public Role()
    {
      this.UserRoles = new List<UserRole>();
    }
  }
}
