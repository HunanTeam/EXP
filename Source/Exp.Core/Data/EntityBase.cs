using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Data
{
    [Serializable]
    public class EntityBase<TKey>
    {
        public TKey Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
