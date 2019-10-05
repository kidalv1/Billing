using DTO.Models;
using System.Data.Entity;

namespace DataContext
{
  public class Data : DbContext
  {
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Vat> Vats { get; set; }
    public DbSet<DetailLine> DetailLines { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Role> Roles { get; set; }
  }
}
