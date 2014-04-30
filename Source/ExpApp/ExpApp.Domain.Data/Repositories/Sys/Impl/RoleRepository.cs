 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Domain.Data.Repositories.Sys.Impl
{
	/// <summary>
    ///   仓储操作层实现——Role
    /// </summary>
    public partial class RoleRepository : EFRepository<Role, Int32>, IRoleRepository
    {
           public RoleRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
