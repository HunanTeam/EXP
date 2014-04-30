 
using System;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.System;


namespace ExpApp.Domain.Data.Repositories.System
{
	/// <summary>
    ///   仓储操作层接口——Module
    /// </summary>
    public partial interface IModuleRepository : IRepository<Module, Int32>
    { }
}
