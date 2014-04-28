using Exp.Core.Domain.Securities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Domain.Users
{
    public partial class User : Base.Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }


        #region 导航属性
        private ICollection<Role> _userRoles;
        public virtual ICollection<Role> UserRoles
        {
            get { return _userRoles ?? (_userRoles = new List<Role>()); }
            protected set { _userRoles = value; }
        }
        #endregion
    }
}
