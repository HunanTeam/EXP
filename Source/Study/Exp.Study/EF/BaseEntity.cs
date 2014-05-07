using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Study.EF
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
