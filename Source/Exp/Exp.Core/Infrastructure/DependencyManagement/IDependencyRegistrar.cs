using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
