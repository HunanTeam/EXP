 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.System;


namespace ExpApp.Domain.Data.Repositories.System.Impl
{
	/// <summary>
    ///   仓储操作层实现——Module
    /// </summary>
    public partial class ModuleRepository : EFRepository<Module, Int32>, IModuleRepository
    {
           public ModuleRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
