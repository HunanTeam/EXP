using System;

namespace Exp.Core.Domain.Base
{
    [Serializable]
    public class EntityBase<TKey>
    {
        public TKey Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
