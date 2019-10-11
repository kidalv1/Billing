using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Configurations
{
  class RoleConfiguration : EntityTypeConfiguration<Role>
  {
    public RoleConfiguration()
    {
      this.ToTable("Role").HasKey<int>(r => r.Id)
        .Property(u => u.Id)
        .HasColumnName("ID")
        .HasColumnOrder(0)
        .HasColumnType("int")
        .IsRequired();

      this.Property(r => r.NameRole)
        .HasColumnName("NameRole")
        .HasColumnOrder(2)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);
    }
  }
}
