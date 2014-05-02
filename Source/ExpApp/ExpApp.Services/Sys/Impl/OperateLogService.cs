
using Exp.Core;
using Exp.Core.Data;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using ExpApp.Site.Models.SysConfig.OperateLog;
using System;
using System.ComponentModel.Composition;
using System.Linq;



namespace ExpApp.Services.Sys.Impl
{
	/// <summary>
    /// 服务层实现 —— OperateLogService
    /// </summary>
   
    public class OperateLogService : CoreServiceBase, IOperateLogService
    {
        public OperateLogService(IRepositoryContext repositoryContext, IOperateLogRepository operateLogRepository)
            : base(repositoryContext)
        {
            this.OperateLogRepository = operateLogRepository;
        }
		#region 属性

		 
        public IOperateLogRepository OperateLogRepository { get; set; }

        public IQueryable<OperateLog> OperateLogs
        {
            get { return OperateLogRepository.Entities; }
        }

		#endregion

		#region 公共方法

        public OperationResult Insert(OperateLogModel model)
        {
            var entity = new OperateLog
            {
				Area = model.Area,
				Controller = model.Controller,
				Action = model.Action,
				Description = model.Description,
				IPAddress = model.IPAddress,
				LoginName = model.LoginName,
				UserId = model.UserId,
				LogTime = model.LogTime
            };
            OperateLogRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Delete()
        {
			var entities = OperateLogRepository.Entities.Where(t => t.IsDeleted == false);
			foreach (var entity in entities)
			{
				entity.IsDeleted = true;
				OperateLogRepository.Update(entity);
			}		
            return new OperationResult(OperationResultType.Success, "删除成功");
		}

		#endregion
	}
}
