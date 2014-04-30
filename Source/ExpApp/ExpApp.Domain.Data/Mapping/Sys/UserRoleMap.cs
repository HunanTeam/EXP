using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpApp.Domain.Models.Sys;
namespace ExpApp.Domain.Data.Mapping.Sys
{
    /// <summary>
    /// 数据表映射 —— UserRole
    /// </summary>    
	partial class UserRoleMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void UserRoleMapAppend()
        {
			// Primary Key
            this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Properties
             
           this.Property(t => t.UserId).HasColumnName("UserId");
            
           this.Property(t => t.RoleId).HasColumnName("RoleId");
            
           this.Property(t => t.CreateId).HasColumnName("CreateId");
            
           this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            
           this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            
           this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            
           this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            
           this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            
           this.Property(t => t.CreateOn).HasColumnName("CreateOn");
                     
            
            // Relation
        }

		
    }
}
