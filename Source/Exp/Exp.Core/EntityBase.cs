﻿using System;

namespace Exp.Core
{
    [Serializable]
    public class EntityBase<Key>
    {
        public Key Id { get; set; }

      
    }
}
