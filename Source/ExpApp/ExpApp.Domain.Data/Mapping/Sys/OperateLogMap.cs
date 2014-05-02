using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpApp.Domain.Models.Sys;
namespace ExpApp.Domain.Data.Mapping.Sys
{
    /// <summary>
    /// 数据表映射 —— OperateLog
    /// </summary>    
	partial class OperateLogMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void OperateLogMapAppend()
        {
			// Primary Key
            this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Properties
             
           this.Property(t => t.Area).HasColumnName("Area");
            
           this.Property(t => t.Controller).HasColumnName("Controller");
            
           this.Property(t => t.Action).HasColumnName("Action");
            
           this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            
           this.Property(t => t.Description).HasColumnName("Description");
            
           this.Property(t => t.LogTime).HasColumnName("LogTime");
            
           this.Property(t => t.LoginName).HasColumnName("LoginName");
            
           this.Property(t => t.UserId).HasColumnName("UserId");
            
           this.Property(t => t.CreateOn).HasColumnName("CreateOn");
            
           this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
                     
            
            // Relation
        }

		
    }
}
