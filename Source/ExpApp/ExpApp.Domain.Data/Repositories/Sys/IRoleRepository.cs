 
using System;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Domain.Data.Repositories.Sys
{
	/// <summary>
    ///   仓储操作层接口——Role
    /// </summary>
    public partial interface IRoleRepository : IRepository<Role, Int32>
    { }
}
