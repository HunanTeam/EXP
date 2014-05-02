using System;
using Exp.Core;


namespace ExpApp.Domain.Models.Base
{
    /// <summary>
    /// 不能在构造函数里赋值
    /// </summary>
    public abstract class Entity : EntityBase<int>
    {
        public DateTime CreateOn { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
