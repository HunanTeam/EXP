 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.System;


namespace ExpApp.Domain.Data.Repositories.System.Impl
{
	/// <summary>
    ///   仓储操作层实现——RoleModulePermission
    /// </summary>
    public partial class RoleModulePermissionRepository : EFRepository<RoleModulePermission, Int32>, IRoleModulePermissionRepository
    {
           public RoleModulePermissionRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
