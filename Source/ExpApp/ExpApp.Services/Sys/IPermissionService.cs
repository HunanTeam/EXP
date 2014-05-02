 

using System;
using System.Linq;

 
using System.Collections.Generic;
using ExpApp.Side.Common.Models;
using Exp.Core;
using ExpApp.Site.Models.Authen.RoleModulePermission;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Services.Sys
{
	/// <summary>
    /// 服务层接口 —— IPermissionService
    /// </summary>
    public interface IPermissionService
    {
        #region 属性

        IQueryable<Permission> Permissions { get; }
      
        #endregion

        #region 公共方法
		/// <summary>
		/// 复选框数据源
		/// </summary>
		/// <returns></returns>
		List<KeyValueModel> GetKeyValueList();

        OperationResult Insert(PermissionModel model);

        OperationResult Update(PermissionModel model);

        OperationResult Delete(int Id);

        #endregion
	}
}
