using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Study.EF.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            this.UserRoles = new List<UserRole>();
        }

        public int Id { get; set; }

        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
