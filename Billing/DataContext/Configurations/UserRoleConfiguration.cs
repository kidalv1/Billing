using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Configurations
{
  class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
  {
    public UserRoleConfiguration()
    {
      this.ToTable("UserRole").HasKey<int>(s => s.Id)
       .Property(c => c.Id)
       .HasColumnName("ID")
       .HasColumnOrder(0)
       .HasColumnType("int")
       .IsRequired();

      this.HasRequired<Role>(u => u.Role)
    .WithMany(r => r.UserRoles)
    .HasForeignKey<int>(s => s.RoleId);

      this.HasRequired<User>(i => i.User)
    .WithMany(c => c.UserRoles)
    .HasForeignKey<int>(s => s.UserId);
    }

  }
}
