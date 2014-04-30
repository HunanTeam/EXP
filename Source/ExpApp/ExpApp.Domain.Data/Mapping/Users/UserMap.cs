﻿using Exp.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;


namespace Exp.Data.Mapping.Users
{
    public partial class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Sys_User");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).HasMaxLength(500); 
            this.Property(c => c.Email).HasMaxLength(500);
            this.Property(c => c.IsDeleted);

            this.HasMany(c => c.UserRoles).WithMany().Map(m=>m.ToTable("Sys_UserRole_Mapping"));
  
        }

    }
}