using DTO.Models;
using System.Data.Entity;

namespace DataContext
{
  class InvoiceContext : DbContext
  {
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Vat> Vats { get; set; }
    public DbSet<DetailLine> DetailLines { get; set; }
  }
}
