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
    public DbSet<Customer> Customers { get; set; }

    IQueryable<Customer> IData.Customers => throw new System.NotImplementedException();

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //Configure default schema
      modelBuilder.HasDefaultSchema("dbo");
      //Map entity to table
      modelBuilder.Configurations.Add(new CustomerConfiguration());
      modelBuilder.Configurations.Add(new VatConfiguration());
      modelBuilder.Configurations.Add(new DetailLineConfiguration());
      modelBuilder.Configurations.Add(new InvoiceConfiguration());
      modelBuilder.Entity<Vat>().MapToStoredProcedures();
      base.OnModelCreating(modelBuilder);

    }
  }
}
