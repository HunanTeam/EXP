
using Exp.Core;
using Exp.Core.Data;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using ExpApp.Site.Common.Models;
using ExpApp.Site.Models.Authen.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

 

namespace ExpApp.Services.Sys.Impl
{
	/// <summary>
    /// 服务层实现 —— RoleService
    /// </summary>
     
    public class RoleService : CoreServiceBase, IRoleService
    {
        public RoleService(IRepositoryContext repositoryContext, IRoleRepository roleRepository)
            : base(repositoryContext)
        {
             
            this.RoleRepository = roleRepository;
        }
        #region 属性

        
        public IRoleRepository RoleRepository { get; set; }

        public IQueryable<Role> Roles
        {
            get { return RoleRepository.Entities; }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 复选框数据源
        /// </summary>
        /// <returns></returns>
        public List<KeyValueModel> GetKeyValueList()
        {
            var keyValueList = new List<KeyValueModel>();
            var dataList = Roles.Where(t => t.Enabled == true && t.IsDeleted == false)
                                .OrderBy(t => t.OrderSort)
								.ToList();
            foreach (var data in dataList)
            {
                keyValueList.Add(new KeyValueModel { Text = data.Name, Value = data.Id.ToString() });
            }
            return keyValueList;
        }

        public OperationResult Insert(RoleModel model)
        {
            var entity = new Role
            {
                Name = model.Name,
                Description = model.Description,
                OrderSort = model.OrderSort,
                Enabled = model.Enabled
            };
            RoleRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Update(RoleModel model)
        {
			var entity = Roles.First(t => t.Id == model.Id);
            entity.Name = model.Name;
			entity.Description = model.Description;
			entity.OrderSort = model.OrderSort;
			entity.Enabled = model.Enabled;

            RoleRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "更新成功");
        }

        public OperationResult Delete(int Id)
        {
            var model = Roles.FirstOrDefault(t => t.Id == Id);
            model.IsDeleted = true;

            RoleRepository.Update(model);
            return new OperationResult(OperationResultType.Success, "删除成功");
        }

        #endregion
    }
}
