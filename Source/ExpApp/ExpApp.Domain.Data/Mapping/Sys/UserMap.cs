using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpApp.Domain.Models.Sys;
namespace ExpApp.Domain.Data.Mapping.Sys
{
    /// <summary>
    /// 数据表映射 —— User
    /// </summary>    
	partial class UserMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void UserMapAppend()
        {
			// Primary Key
            this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Properties
             
           this.Property(t => t.LoginName).HasColumnName("LoginName");
            
           this.Property(t => t.LoginPwd).HasColumnName("LoginPwd");
            
           this.Property(t => t.FullName).HasColumnName("FullName");
            
           this.Property(t => t.Email).HasColumnName("Email");
            
           this.Property(t => t.Phone).HasColumnName("Phone");
            
           this.Property(t => t.Enabled).HasColumnName("Enabled");
            
           this.Property(t => t.PwdErrorCount).HasColumnName("PwdErrorCount");
            
           this.Property(t => t.LoginCount).HasColumnName("LoginCount");
            
           this.Property(t => t.RegisterTime).HasColumnName("RegisterTime");
            
           this.Property(t => t.LastLoginTime).HasColumnName("LastLoginTime");
            
           this.Property(t => t.CreateId).HasColumnName("CreateId");
            
           this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            
           this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            
           this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            
           this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            
           this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            
           this.Property(t => t.CreateOn).HasColumnName("CreateOn");
            
           this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
                     
            
            // Relation
        }

		
    }
}
