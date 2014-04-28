using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Securities
{
    public partial class Role : Base.Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnabled { get; set; }

    }
}
