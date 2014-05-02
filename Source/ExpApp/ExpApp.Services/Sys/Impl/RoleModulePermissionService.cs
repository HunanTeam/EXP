
using Exp.Core;
using Exp.Core.Data;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services;
using ExpApp.Services.Sys;
using ExpApp.Site.Models.Authen.RoleModulePermission;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;




namespace ExpApp.Services.Sys.Impl
{
	/// <summary>
    /// 服务层实现 —— RoleModulePermissionService
    /// </summary>
  
    public class RoleModulePermissionService : CoreServiceBase, IRoleModulePermissionService
    {

        public RoleModulePermissionService(IRepositoryContext repositoryContext, IRoleModulePermissionRepository roleModulePermissionRepository)
            : base(repositoryContext)
        {
            this.RoleModulePermissionRepository = roleModulePermissionRepository;
            
        }
        #region 属性

        
        public IRoleModulePermissionRepository RoleModulePermissionRepository { get; set; }

        public IQueryable<RoleModulePermission> RoleModulePermissions
        {
            get { return RoleModulePermissionRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult SetRoleModulePermission(int roleId, IEnumerable<RoleModulePermissionModel> addModulePermissionList, IEnumerable<RoleModulePermissionModel> removeModulePermissionList)
        {
            //逻辑删除
            if (removeModulePermissionList.Count() > 0)
            {
                foreach (var rmp in removeModulePermissionList)
                {
                    var updateEntity = RoleModulePermissions.FirstOrDefault(t => t.RoleId == roleId && t.ModuleId == rmp.ModuleId && t.PermissionId == rmp.PermissionId && t.IsDeleted == false);
                    if (updateEntity != null)
                    {
                        updateEntity.IsDeleted = true;
                        RoleModulePermissionRepository.Update(updateEntity);
                    }
                }         
            }
            //插入 & 更新
            if (addModulePermissionList.Count() > 0)
            {
                foreach (var amp in addModulePermissionList)
                {
                    var updateEntity = RoleModulePermissions.FirstOrDefault(t => t.RoleId == roleId && t.ModuleId == amp.ModuleId && t.PermissionId == amp.PermissionId && t.IsDeleted == true);
                    if (updateEntity != null)
                    {
                        updateEntity.IsDeleted = false;
                        RoleModulePermissionRepository.Update(updateEntity);
                    }
                    else 
                    {
                        var addEntity = new RoleModulePermission
                        {
                            RoleId = roleId,
                            ModuleId = amp.ModuleId,
                            PermissionId = amp.PermissionId
                        };
                        RoleModulePermissionRepository.Insert(addEntity);
                    }
                }
            }

			return new OperationResult(OperationResultType.Success, "授权成功");
        }       

        #endregion
    }
}
