using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Users
{
    public class User : Base.EntityBase<int>
    {
        public string Name { get; set; }
    }
}
