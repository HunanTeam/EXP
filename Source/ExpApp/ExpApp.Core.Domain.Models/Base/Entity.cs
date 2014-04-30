using System;
using ExpApp.Core;

namespace ExpApp.Domain.Models.Base
{
    /// <summary>
    /// 不能在构造函数里赋值
    /// </summary>
    public class Entity : EntityBase<int>
    {
        public DateTime CreateOn { get; set; }
    }
}
