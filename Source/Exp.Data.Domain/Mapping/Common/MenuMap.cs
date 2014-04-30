
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Exp.Data.Mapping.Common
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            this.ToTable("Sys_Menu");
            this.HasOptional(m => m.ParentMenu).WithMany(c => c.ChildMenus)
                .HasForeignKey(d => d.ParentMenuId).WillCascadeOnDelete(false);
            this.Property(c => c.Title);

        }
    }
}
