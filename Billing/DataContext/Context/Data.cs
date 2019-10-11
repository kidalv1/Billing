using DataContext.Configurations;
using DTO.Models;
using System.Data.Entity;
using System.Linq;

namespace DataContext
{
  public class Data : DbContext , IData
  {
    public Data() : base("conn")
    {
        
    }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Vat> Vats { get; set; }
    public DbSet<DetailLine> DetailLines { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Role> Roles { get; set; }

    IQueryable<User> IData.Users
    {
      get { return Users; }
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //Configure default schema
      modelBuilder.HasDefaultSchema("Admin");

      //Map entity to table
      modelBuilder.Configurations.Add(new UserConfiguration());
      modelBuilder.Configurations.Add(new CustomerConfiguration());
      modelBuilder.Configurations.Add(new RoleConfiguration());
      modelBuilder.Configurations.Add(new VatConfiguration());
      modelBuilder.Configurations.Add(new DetailLineConfiguration());
      modelBuilder.Configurations.Add(new InvoiceConfiguration());
    }
  }
}
