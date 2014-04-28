using Exp.Core.Domain.Securities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Exp.Data.Mapping.Securities
{
    public partial class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Sys_Role");
            this.HasKey(c => c.Id);
            
 
        }
    }
}
