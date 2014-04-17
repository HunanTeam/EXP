using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.AuoMapperDo
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public IEnumerable<Address> Addresss { get; set; }

    }

}
