

using Exp.Core;
using Exp.Core.Domain.System;
using Exp.Site.Models.Authen.Permission;
using System;
using System.Linq;




namespace QuickRMS.Core.Service.Authen
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
