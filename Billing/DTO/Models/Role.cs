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
    public int Id { get; set; }
    public string NameRole { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public Role()
    {
    }
  }
}
