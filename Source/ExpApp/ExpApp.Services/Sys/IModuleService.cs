using System.Linq;
using Exp.Core;
using ExpApp.Site.Models.Authen.Module;
using ExpApp.Domain.Models.Sys;
using System.Collections.Generic;

namespace ExpApp.Services.Sys
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

        #region 查询
        IList<ModuleModel> QueryParentModules();
        IList<ModuleModel> QueryModuleModels();
        #endregion
    }
}
