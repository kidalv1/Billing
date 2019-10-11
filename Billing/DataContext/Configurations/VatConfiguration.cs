using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Configurations
{
  class VatConfiguration : EntityTypeConfiguration<Vat>
  {
    public VatConfiguration()
    {
      this.ToTable("VAT").HasKey<int>(v => v.Id)
        .Property(u => u.Id)
        .HasColumnName("ID")
        .HasColumnOrder(0)
        .HasColumnType("int")
        .IsRequired();

      this.Property(v => v.Percentage)
        .HasColumnName("Percentage")
        .HasColumnOrder(1)
        .HasColumnType("int")
        .IsRequired();


    }
  }
}
