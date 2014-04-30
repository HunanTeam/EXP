 

using System;
using System.Linq;
using ExpApp.Domain.Models.System;


namespace ExpApp.Services.System
{
	/// <summary>
    /// 服务层接口 —— IUserRoleService
    /// </summary>
    public interface IUserRoleService
    {
        #region 属性

        IQueryable<UserRole> UserRoles { get; }

        #endregion

        #region 公共方法

        #endregion
	}
}
