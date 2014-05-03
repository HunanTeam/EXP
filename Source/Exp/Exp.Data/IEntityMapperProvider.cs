using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Data
{
   public interface IEntityMapperProvider
    {
       IEnumerable<IEntityMapper> EntityMappers { get; }
    }
}
