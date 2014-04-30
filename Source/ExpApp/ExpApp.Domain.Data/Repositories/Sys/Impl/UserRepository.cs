 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Domain.Data.Repositories.Sys.Impl
{
	/// <summary>
    ///   仓储操作层实现——User
    /// </summary>
    public partial class UserRepository : EFRepository<User, Int32>, IUserRepository
    {
           public UserRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
