﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpApp.Domain.Models.System;
namespace ExpApp.Domain.Data.Mapping.System
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

            // Properties
            
            // Table & Column Mappings
            this.ToTable("");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            // Relation
        }

		
    }
}
