﻿ 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Domain.Data.Repositories.Sys.Impl
{
	/// <summary>
    ///   仓储操作层实现——UserRole
    /// </summary>
    public partial class UserRoleRepository : EFRepository<UserRole, Int32>, IUserRoleRepository
    {
           public UserRoleRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
