using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Study.NewLifeDo
{
    public class Customer : XCode.Entity<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
