using System.Linq;
using ExpApp.Core;
using ExpApp.Site.Models.Authen.RoleModulePermission;
using ExpApp.Domain.Models.System;

namespace ExpApp.Services.System
{
	/// <summary>
    /// 服务层接口 —— IModuleService
    /// </summary>
    public interface IModuleService
    {
        #region 属性

        IQueryable<Module> Modules { get; }

        #endregion

        #region 公共方法

        OperationResult Insert(ModuleModel model);

        OperationResult Update(ModuleModel model);

        OperationResult Delete(int Id);

        #endregion
	}
}
