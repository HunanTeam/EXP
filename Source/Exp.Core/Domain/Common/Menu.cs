using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Common
{
    public class Menu : Base.Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 小图标的url
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        public string Desc { get; set; }

        public int Index { get; set; }

        public int? ParentMenuId { get; set; }

        public virtual Menu ParentMenu { get; set; }

        public virtual ICollection<Menu> ChildMenus
        {
            get;
            set;
        }
    }
}
