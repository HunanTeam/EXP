using System.Collections.Generic;
using System.Linq;
using Exp.Core;
using ExpApp.Site.Models.Authen.RoleModulePermission;
using ExpApp.Domain.Models.Sys;

namespace ExpApp.Services.Sys
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
