 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.System;


namespace ExpApp.Domain.Data.Repositories.System.Impl
{
	/// <summary>
    ///   仓储操作层实现——Permission
    /// </summary>
    public partial class PermissionRepository : EFRepository<Permission, Int32>, IPermissionRepository
    {
           public PermissionRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
