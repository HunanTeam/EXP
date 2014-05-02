using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Infrastructure
{
    /// <summary>
    /// 程序启动的时候需要执行的任务
    /// 系统启动后会扫描所有程序集
    /// </summary>
    public interface IStartupTask
    {
        void Execute();

        int Order { get; }
    }
}
