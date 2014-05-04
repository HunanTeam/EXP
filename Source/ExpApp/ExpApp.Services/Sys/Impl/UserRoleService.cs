
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using System;
using System.ComponentModel.Composition;
using System.Linq;


namespace ExpApp.Services.Sys.Impl
{
	/// <summary>
    /// 服务层实现 —— UserRoleService
    /// </summary>
   
    public class UserRoleService : IUserRoleService
	{
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            this.UserRoleRepository = userRoleRepository;
        }
            
		#region 属性

		 
        public IUserRoleRepository UserRoleRepository { get; set; }

        public IQueryable<UserRole> UserRoles
        {
            get { return UserRoleRepository.Entities; }
		}

		#endregion
	}
}
