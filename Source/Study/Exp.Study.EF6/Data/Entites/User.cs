using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exp.Study.EF6.Data.Entites
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public int AddressId { get; set; }


        public Address Address { get; set; }


    }
}