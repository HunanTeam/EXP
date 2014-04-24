﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Exp.Core.Domain.Users;

namespace Exp.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Sys_User");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).HasMaxLength(500);
        }

    }
}
