
using Exp.Core;
using Exp.Core.Data;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using ExpApp.Site.Models.Authen.Module;
using System;
using System.ComponentModel.Composition;
using System.Linq;

 


namespace ExpApp.Services.Sys.Impl
{
	/// <summary>
    /// 服务层实现 —— ModuleService
    /// </summary>
    
    public class ModuleService : CoreServiceBase, IModuleService
	{
        public ModuleService(IRepositoryContext repositoryContext, IModuleRepository moduleRepository)
            : base(repositoryContext)
        {
            this.ModuleRepository = moduleRepository;
        }
		#region 属性

		 
        public IModuleRepository ModuleRepository { get; set; }

        public IQueryable<Module> Modules
        {
            get { return ModuleRepository.Entities; }
        }

		#endregion

		#region 公共方法

		public OperationResult Insert(ModuleModel model)
        {
            var entity = new Module
            {
                Name = model.Name,
                Code = model.Code,
                ParentId = model.ParentId != 0 ? model.ParentId : null,
                LinkUrl = model.LinkUrl,
                Area = model.Area,
                Controller = model.Controller,
                Action = model.Action,
                OrderSort = model.OrderSort,
                Icon = model.Icon != null ? model.Icon : "",
                Enabled = model.Enabled
            };
            ModuleRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Update(ModuleModel model)
        {
            var entity = new Module
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                ParentId = model.ParentId != 0 ? model.ParentId : null,
                LinkUrl = model.LinkUrl,
                Area = model.Area,
                Controller = model.Controller,
                Action = model.Action,
                OrderSort = model.OrderSort,
				Icon = model.Icon != null ? model.Icon : "",
                Enabled = model.Enabled
            };          
            ModuleRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "更新成功");
        }

        public OperationResult Delete(int Id)
        {
			var model = Modules.FirstOrDefault(t => t.Id == Id);
			model.IsDeleted = true;

			ModuleRepository.Update(model);
			return new OperationResult(OperationResultType.Success, "删除成功");
		}

		#endregion
	}
}
