using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Configurations
{
  class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
  {
    public InvoiceConfiguration()
    {
      this.ToTable("Invoice").HasKey<int>(s => s.Id)
       .Property(c => c.Id)
       .HasColumnName("ID")
       .HasColumnOrder(0)
       .HasColumnType("int")
       .IsRequired();

      this.Property(d => d.Date)
     .HasColumnName("Date")
     .HasColumnOrder(2)
     .HasColumnType("date")
     .IsRequired();

      this.Property(d => d.Reason)
     .HasColumnName("Reason")
     .HasColumnOrder(3)
     .HasColumnType("varchar");

      this.Property(d => d.Active)
     .HasColumnName("Active")
     .HasColumnOrder(4)
     .HasColumnType("bit")
     .IsRequired();

      this.HasRequired<User>(i => i.User)
    .WithMany(i => i.Invoices)
    .HasForeignKey<int>(s => s.UserId);

      this.HasRequired<Customer>(i => i.Customer)
    .WithMany(c => c.Invoices)
    .HasForeignKey<int>(s => s.CustomerId);


    }
  }
}
