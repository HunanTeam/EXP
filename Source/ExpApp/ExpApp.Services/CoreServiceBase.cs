using Exp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Services
{
    /// <summary>
    /// 核心业务实现基类
    /// </summary>
    public abstract class CoreServiceBase
    {
        protected CoreServiceBase(IRepositoryContext context)
        {
            this.UnitOfWork = context;
        }
        /// <summary>
        /// 获取或设置工作单元对象，用于处理同步业务的事务操作
        /// </summary>

        protected IUnitOfWork UnitOfWork { get; set; }
    }
}
