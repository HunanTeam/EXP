
using Exp.Core;
using Exp.Core.Data;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services;
using ExpApp.Site.Models.Authen.Permission;
using System;
using System.ComponentModel.Composition;
using System.Linq;



namespace ExpApp.Services.Sys.Impl
{
	/// <summary>
    /// 服务层实现 —— ModulePermissionService
    /// </summary>
    
    public class ModulePermissionService : CoreServiceBase, IModulePermissionService
	{
        public ModulePermissionService(IRepositoryContext repositoryContext, IModulePermissionRepository modulePermissionRepository)
            : base(repositoryContext)
        {
            this.ModulePermissionRepository = modulePermissionRepository;
        }
		#region 属性

 
        public IModulePermissionRepository ModulePermissionRepository { get; set; }

        public IQueryable<ModulePermission> ModulePermissions
        {
            get { return ModulePermissionRepository.Entities; }
        }

		#endregion

		#region 公共方法

		public OperationResult SetButton(ButtonModel model)
        {
			#region Add & Update 
			var oldDataList = ModulePermissions.Where(t => t.ModuleId == model.ModuleId && t.IsDeleted == false).Select(t => t.PermissionId);
			var newDataList = model.SelectedButtonList.ToList();
			var intersectIds = oldDataList.Intersect(newDataList).ToList(); // Same Ids
			var updateIds = oldDataList.Except(intersectIds).ToList(); // Remove Ids
			var addIds = newDataList.Except(oldDataList).ToList(); // Add Ids
			//逻辑删除
			foreach (var removeId in updateIds)
			{
				var updateEntity = ModulePermissions.FirstOrDefault(t => t.ModuleId == model.ModuleId && t.PermissionId == removeId && t.IsDeleted == false);
				if (updateEntity != null)
				{
					updateEntity.IsDeleted = true;
					ModulePermissionRepository.Update(updateEntity);
				}
				
			}
			//插入 & 更新
			foreach (var addId in addIds)
			{
				var updateEntity = ModulePermissions.FirstOrDefault(t => t.ModuleId == model.ModuleId && t.PermissionId == addId && t.IsDeleted == true);
				if (updateEntity != null)
				{
					updateEntity.IsDeleted = false;
					ModulePermissionRepository.Update(updateEntity);
				}
				else
				{
					var addEntity = new ModulePermission { ModuleId = model.ModuleId, PermissionId = addId };
					ModulePermissionRepository.Insert(addEntity);
				}			
			}
			#endregion

            return new OperationResult(OperationResultType.Success, "设置成功");
		}

		#endregion
	}
}
