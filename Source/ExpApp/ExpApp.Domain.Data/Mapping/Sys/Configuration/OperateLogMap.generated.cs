﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//
// <copyright file="OperateLogMap.generated.cs">
 
//		生成时间：2014-05-02 23:51
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Exp.Data;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Domain.Data.Mapping.Sys
{
    /// <summary>
    /// 数据表映射 —— OperateLog
    /// </summary>    
	internal partial class OperateLogMap : EntityTypeConfiguration<OperateLog>, IEntityMapper
    {
        /// <summary>
        /// OperateLog-数据表映射构造函数
        /// </summary>
        public OperateLogMap()
        {
			OperateLogMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void OperateLogMapAppend();
		
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
