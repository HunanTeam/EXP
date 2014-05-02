using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// 系统启动后会扫描所有程序集进行注册
    /// </summary>
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
