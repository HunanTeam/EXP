 
using System;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.System;


namespace ExpApp.Domain.Data.Repositories.System
{
	/// <summary>
    ///   仓储操作层接口——UserRole
    /// </summary>
    public partial interface IUserRoleRepository : IRepository<UserRole, Int32>
    { }
}
