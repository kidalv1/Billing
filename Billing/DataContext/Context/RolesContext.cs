using DTO.Models;
using System.Data.Entity;

namespace DataContext
{
  class RolesContext : DbContext
  {
    public DbSet<Role> Roles { get; set; }
  }
}
