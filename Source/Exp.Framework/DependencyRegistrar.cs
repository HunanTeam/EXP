using Autofac;
using Autofac.Integration.Mvc;
using Exp.Core;
using Exp.Core.Fakes;
using Exp.Core.Infrastructure.DependencyManagement;
using Exp.Core.Plugins;
using Exp.Framework.Themes;
using Exp.Services.Common;
using Exp.Services.Common.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Exp.Framework
{
  public  class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, Core.Infrastructure.ITypeFinder typeFinder)
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
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
