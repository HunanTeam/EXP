 

using ExpApp.Core;
using ExpApp.Side.Common.Models;
using ExpApp.Site.Models.Authen.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpApp.Domain.Models.System;


namespace ExpApp.Services.System
{
	/// <summary>
    /// 服务层接口 —— IRoleService
    /// </summary>
    public interface IRoleService
    {
		#region 属性

        IQueryable<Role> Roles { get; }

        #endregion

        #region 公共方法
        /// <summary>
        /// 复选框数据源
        /// </summary>
        /// <returns></returns>
        List<KeyValueModel> GetKeyValueList();

        OperationResult Insert(RoleModel model);

        OperationResult Update(RoleModel model);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(int Id);

        #endregion
	}
}
