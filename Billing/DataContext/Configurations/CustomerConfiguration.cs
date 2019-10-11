using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Configurations
{
  class CustomerConfiguration : EntityTypeConfiguration<Customer>
  {
    public CustomerConfiguration()
    {
      this.ToTable("Customer").HasKey<int>(s => s.Id)
       .Property(c => c.Id)
       .HasColumnName("ID")
       .HasColumnOrder(0)
       .HasColumnType("int")
       .IsRequired();

      this.Property(c => c.Firstname)
        .HasColumnName("Firstname")
        .HasColumnOrder(1)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(c => c.Lastname)
        .HasColumnName("Lastname")
        .HasColumnOrder(2)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(u => u.Email)
        .HasColumnName("Email")
        .HasColumnOrder(3)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);

      this.Property(u => u.Company)
        .HasColumnName("Company")
        .HasColumnOrder(4)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);

      this.Property(u => u.Visibility)
        .HasColumnName("Visibility")
        .HasColumnOrder(5)
        .HasColumnType("bit")
        .IsRequired();
    }
  }
}
