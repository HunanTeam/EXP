using Exp.Core;
using ExpApp.Domain.Models.Sys;
using ExpApp.Site.Models.SysConfig.OperateLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Services.Sys
{
    public interface IOperateLogService
    {
        #region 属性

        IQueryable<OperateLog> OperateLogs { get; }

        #endregion

        #region 公共方法

        OperationResult Insert(OperateLogModel model);

        OperationResult Delete();

        #endregion
    }
}
