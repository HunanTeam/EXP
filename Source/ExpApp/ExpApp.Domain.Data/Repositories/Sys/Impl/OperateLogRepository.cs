 
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Models.Sys;


namespace ExpApp.Domain.Data.Repositories.Sys.Impl
{
	/// <summary>
    ///   仓储操作层实现——OperateLog
    /// </summary>
    public partial class OperateLogRepository : EFRepository<OperateLog, Int32>, IOperateLogRepository
    {
           public OperateLogRepository(IRepositoryContext repositoryContext):base(repositoryContext)
        {
            

        }
     }
}
