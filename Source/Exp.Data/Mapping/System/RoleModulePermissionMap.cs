using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;
using Exp.Core.Domain.System;


namespace Exp.Data.Mapping.System
{
    /// <summary>
    /// 数据表映射 —— RoleModulePermissionMap
    /// </summary>   
    partial class RoleModulePermissionMap : EntityTypeConfiguration<RoleModulePermission>
    {
        /// <summary>
        /// 映射配置
        /// </summary>   		
        public void RoleModulePermissionMapAppend()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Sys_Auth_RoleModulePermission");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.RoleId).HasColumnName("RoleId");
			this.Property(t => t.ModuleId).HasColumnName("ModuleId");
			this.Property(t => t.PermissionId).HasColumnName("PermissionId");

            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");

            // Relation
			this.HasRequired(t => t.Role).WithMany(d => d.RoleModulePermission).HasForeignKey(f => f.RoleId).WillCascadeOnDelete(true);
			this.HasRequired(t => t.Module).WithMany(d => d.RoleModulePermission).HasForeignKey(f => f.ModuleId).WillCascadeOnDelete(true);
			this.HasOptional(t => t.Permission).WithMany(d => d.RoleModulePermission).HasForeignKey(f => f.PermissionId).WillCascadeOnDelete(true);
		}
    }
}
