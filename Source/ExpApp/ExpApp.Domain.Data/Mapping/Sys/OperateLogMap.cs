using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpApp.Domain.Models.Sys;
namespace ExpApp.Domain.Data.Mapping.Sys
{
    partial class OperateLogMap
    {
        /// <summary>
        /// 映射配置
        /// </summary>   		
        partial void OperateLogMapAppend()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Area)
                .HasMaxLength(50);

            this.Property(t => t.Controller)
                .HasMaxLength(50);

            this.Property(t => t.Action)
                .HasMaxLength(50);

            this.Property(t => t.IPAddress)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.LoginName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysConfig_OperateLog");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LogTime).HasColumnName("LogTime");
            this.Property(t => t.LoginName).HasColumnName("LoginName");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relation
            this.HasRequired(t => t.User).WithMany(d => d.OperateLog).HasForeignKey(f => f.UserId).WillCascadeOnDelete(true);
        }
    }
}
