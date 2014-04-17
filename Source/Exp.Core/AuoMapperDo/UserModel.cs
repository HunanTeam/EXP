using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.AuoMapperDo
{
    public class UserModel
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public IEnumerable<AddressModel> Addresss { get; set; }
    }
}
