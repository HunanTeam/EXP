using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core
{
    public static class Ioc
    {

        public static T Get<T>() where T : class
        {
          return  Exp.Core.Infrastructure.EngineContext.Current.Resolve<T>();
        }


        public static T Get<T>(string key) where T : class
        {
            return Exp.Core.Infrastructure.EngineContext.Current.ContainerManager.Resolve<T>(key);
        }
    }
}
