using Autofac;
using Autofac.Integration.Mvc;
using Exp.Core;
using Exp.Core.Data;
using Exp.Core.Fakes;
using Exp.Core.Infrastructure;
using Exp.Core.Infrastructure.DependencyManagement;

using Exp.Core.Plugins;
using Exp.Data;
using ExpApp.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using ExpApp.Services.Common;
using ExpApp.Services.Common.Impl;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Data.Repositories.Sys.Impl;
using ExpApp.Services.Sys;
using ExpApp.Services.Sys.Impl;
using ExpApp.Domain.Data;
namespace ExpApp.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder,ITypeFinder typeFinder)
        {
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();
            //
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();


            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            //plugins
            builder.RegisterType<PluginFinder>().As<IPluginFinder>().InstancePerHttpRequest();


            builder.RegisterType<MobileDeviceHelper>().As<IMobileDeviceHelper>().InstancePerHttpRequest();
            builder.RegisterType<ThemeProvider>().As<IThemeProvider>().InstancePerHttpRequest();
            builder.RegisterType<ThemeContext>().As<IThemeContext>().InstancePerHttpRequest();


            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();
            IEntityMapperProvider entityMapperProvider = new EntityMapperProvider();
            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
              
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                //动态切换
                var dataProvider = (IDataProvider)efDataProviderManager.LoadDataProvider(); 
     
                dataProvider.InitDatabase();

               
                builder.Register<IRepositoryContext>(c => new EFRepositoryContext(dataProviderSettings.DataConnectionString, entityMapperProvider.EntityMappers)).InstancePerHttpRequest();
            }
            else
            {
                builder.Register<IRepositoryContext>(c => new EFRepositoryContext(dataSettingsManager.LoadSettings().DataConnectionString, entityMapperProvider.EntityMappers)).InstancePerHttpRequest();
            }
          
            builder.RegisterGeneric(typeof(EFRepository<,>)).As(typeof(IRepository<,>)).InstancePerHttpRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerHttpRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerHttpRequest();
            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>().InstancePerHttpRequest();
            builder.RegisterType<PermissionRepository>().As<IPermissionRepository>().InstancePerHttpRequest();
            builder.RegisterType<RoleModulePermissionRepository>().As<IRoleModulePermissionRepository>().InstancePerHttpRequest();
            builder.RegisterType<ModuleRepository>().As<IModuleRepository>().InstancePerHttpRequest();
            builder.RegisterType<ModulePermissionRepository>().As<IModulePermissionRepository>().InstancePerHttpRequest();
            builder.RegisterType<OperateLogRepository>().As<IOperateLogRepository>().InstancePerHttpRequest();
            
            //Service
            builder.RegisterType<ModulePermissionService>().As<IModulePermissionService>().InstancePerHttpRequest();
            builder.RegisterType<ModuleService>().As<IModuleService>().InstancePerHttpRequest();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerHttpRequest();
            builder.RegisterType<RoleModulePermissionService>().As<IRoleModulePermissionService>().InstancePerHttpRequest();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerHttpRequest();
            builder.RegisterType<UserRoleService>().As<IUserRoleService>().InstancePerHttpRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            builder.RegisterType<OperateLogService>().As<IOperateLogService>().InstancePerHttpRequest();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
