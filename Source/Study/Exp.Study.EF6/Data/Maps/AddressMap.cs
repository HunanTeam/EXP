using Exp.Study.EF6.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Exp.Study.EF6.Data.Maps
{
    public class AddressMap: EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.HasKey(p=>p.Id);
        }
    }
}