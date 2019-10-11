using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DataContext.Configurations
{
  class UserConfiguration : EntityTypeConfiguration<User>
  {
    public UserConfiguration()
    {
      this.ToTable("User").HasKey<int>(s => s.Id)
        .Property(u => u.Id)
        .HasColumnName("ID")
        .HasColumnOrder(0)
        .HasColumnType("int")
        .IsRequired();

      this.Property(u => u.Firstname)
        .HasColumnName("Firstname")
        .HasColumnOrder(1)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(u => u.Lastname)
        .HasColumnName("Lastname")
        .HasColumnOrder(2)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(u => u.Password)
        .HasColumnName("Password")
        .HasColumnOrder(3)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(u => u.Resettoken)
        .HasColumnName("Resettoken")
        .HasColumnOrder(4)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      this.Property(u => u.Email)
        .HasColumnName("Email")
        .HasColumnOrder(5)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

      

    }

  }
}
