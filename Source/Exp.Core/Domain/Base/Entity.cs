using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Base
{
    /// <summary>
    /// 不能在构造函数里赋值
    /// </summary>
    public class Entity : EntityBase<int>
    {
        public DateTime CreateOn { get; set; }
    }
}
