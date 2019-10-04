
using System.Data.Entity;
using DTO.Models;


namespace DataContext
{
    public class PersonContext : DbContext
    {
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
  }
}
