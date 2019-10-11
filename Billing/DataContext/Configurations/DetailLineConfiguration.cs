using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Configurations
{
  class DetailLineConfiguration : EntityTypeConfiguration<DetailLine>
  {
    public DetailLineConfiguration()
    {
      this.ToTable("DetailLine").HasKey<int>(d => d.Id)
        .Property(d => d.Id)
        .HasColumnName("ID")
        .HasColumnOrder(0)
        .HasColumnType("int")
        .IsRequired();

      this.Property(d => d.Item)
        .HasColumnName("Item")
        .HasColumnOrder(1)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(d => d.PricePiece)
        .HasColumnName("PricePiece")
        .HasColumnOrder(2)
        .HasColumnType("decimal")
        .HasPrecision(10,2)
        .IsRequired();

      this.Property(d => d.Discount)
      .HasColumnName("Discount")
      .HasColumnOrder(3)
      .HasColumnType("decimal")
      .HasPrecision(4, 2);

      this.Property(d => d.CountOfItems)
      .HasColumnName("CountOfItems")
      .HasColumnOrder(4)
      .HasColumnType("int")
      .IsRequired();

      this.HasRequired<Vat>(s => s.Vat)
    .WithMany(d => d.DetailLines)
    .HasForeignKey<int>(s => s.VatId);

      this.HasRequired<Invoice>(s => s.Invoice)
    .WithMany(d => d.DetailLines)
    .HasForeignKey<int>(s => s.InvoiceId);
    }
  }
}
