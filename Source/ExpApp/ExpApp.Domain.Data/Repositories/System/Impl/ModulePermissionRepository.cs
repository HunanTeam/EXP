 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.System;


namespace ExpApp.Domain.Data.Repositories.System.Impl
{
	/// <summary>
    ///   仓储操作层实现——ModulePermission
    /// </summary>
    public partial class ModulePermissionRepository : EFRepository<ModulePermission, Int32>, IModulePermissionRepository
    {
           public ModulePermissionRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
