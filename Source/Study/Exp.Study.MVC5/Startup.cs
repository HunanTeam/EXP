using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exp.Study.MVC5.Startup))]
namespace Exp.Study.MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
