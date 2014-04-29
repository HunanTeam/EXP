 
using System;
using System.Linq;
using System.Collections.Generic;

 
using Exp.Core;
using Exp.Core.Domain.System;


namespace Exp.Services.System
{
	/// <summary>
    /// 服务层接口 —— IRoleModulePermissionService
    /// </summary>
	public interface IRoleModulePermissionService
    {
        #region 属性

		IQueryable<RoleModulePermission> RoleModulePermissions { get; }

        #endregion

        #region 公共方法

        OperationResult SetRoleModulePermission(int roleId, IEnumerable<RoleModulePermissionModel> addModulePermissionList, IEnumerable<RoleModulePermissionModel> removeModulePermissionList);
        
        #endregion
    }
}
