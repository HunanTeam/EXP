using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Users
{
    public partial class User : Base.Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
