﻿using System;
using System.ComponentModel.DataAnnotations.Schema;




namespace ExpApp.Domain.Data.Mapping.Sys
{
    /// <summary>
    /// 数据表映射 —— ModuleMap
    /// </summary>   
	partial class ModuleMap
    {
		/// <summary>
		/// 映射配置
		/// </summary>   		
        partial void ModuleMapAppend()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.LinkUrl)
                .HasMaxLength(100);

            this.Property(t => t.Icon)
                .HasMaxLength(100);

            this.Property(t => t.Code)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Properties
            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Common_Auth_Module");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LinkUrl).HasColumnName("LinkUrl");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.Action).HasColumnName("Action");            
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.OrderSort).HasColumnName("OrderSort");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsMenu).HasColumnName("IsMenu");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");

            // Relation
			this.HasOptional(t => t.ParentModule).WithMany(t => t.ChildModule).HasForeignKey(d => d.ParentId);
		}
    }
}
