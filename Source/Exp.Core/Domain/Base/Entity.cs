using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Base
{
    public class Entity : EntityBase<int>
    {
        public Entity()
        {
            this.CreateOn = DateTime.Now;
        }
        public DateTime CreateOn { get; set; }
    }
}
