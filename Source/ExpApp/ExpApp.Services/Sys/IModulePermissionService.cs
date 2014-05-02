using System.Linq;
using Exp.Core;

using ExpApp.Site.Models.Authen.Permission;
using ExpApp.Domain.Models.Sys;

namespace ExpApp.Services.Sys
{
	/// <summary>
    /// 服务层接口 —— IModulePermissionService
    /// </summary>
    public interface IModulePermissionService
    {
        #region 属性

        IQueryable<ModulePermission> ModulePermissions { get; }

        #endregion

        #region 公共方法

		OperationResult SetButton(ButtonModel model);

        #endregion
	}
}
