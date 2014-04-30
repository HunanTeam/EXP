

using Exp.Core;
using Exp.Core.Domain.System;
using Exp.Site.Models.Authen.User;
using System;
using System.Linq;
 


namespace Exp.Services.System
{
	/// <summary>
    /// 服务层接口 —— IUserService
    /// </summary>
    public interface IUserService
    {
		#region 属性

        IQueryable<User> Users { get; }

        #endregion

        #region 公共方法

        OperationResult Insert(UserModel model);

        OperationResult Update(User model);

        OperationResult Update(UpdateUserModel model);

		OperationResult Update(ChangePwdModel model);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(UserModel model);

        #endregion
	}
}
