using ExpApp.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Core.Infrastructure.DependencyManagement
{
  public  class ContainerConfigurer
    {
        public virtual void Configure(IEngine engine, ContainerManager containerManager, AppConfig configuration)
        {
            //other dependencies
            containerManager.AddComponentInstance<AppConfig>(configuration, "exp.app.configuration");
            containerManager.AddComponentInstance<IEngine>(engine, "exp.app.engine");
            containerManager.AddComponentInstance<ContainerConfigurer>(this, "exp.app.containerConfigurer");

            //type finder
            containerManager.AddComponent<ITypeFinder, WebAppTypeFinder>("exp.app.typeFinder");

            //register dependencies provided by other assemblies
            var typeFinder = containerManager.Resolve<ITypeFinder>();
            containerManager.UpdateContainer(x =>
            {
                var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                var drInstances = new List<IDependencyRegistrar>();
                foreach (var drType in drTypes)
                    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
                //sort
                drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
                foreach (var dependencyRegistrar in drInstances)
                    dependencyRegistrar.Register(x, typeFinder);
            });
        }
    }
}
