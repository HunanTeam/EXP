using System;

namespace ExpApp.Core
{
    [Serializable]
    public class EntityBase<Key>
    {
        public Key Id { get; set; }

      
    }
}
