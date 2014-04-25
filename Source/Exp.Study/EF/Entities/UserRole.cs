using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Exp.Study.EF.Entities
{
    public class UserRole
    {
        public User User { get; set; }

        public int UserId { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }
    }

    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.HasKey(o => new { o.UserId, o.RoleId });
            this.HasRequired(o => o.User).WithMany(o => o.UserRoles).HasForeignKey(o => o.RoleId);
            this.HasRequired(o => o.Role).WithMany(o => o.UserRoles).HasForeignKey(o => o.UserId);
        }
    }
}
