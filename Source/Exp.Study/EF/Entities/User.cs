using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Exp.Study.EF.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.UserRoles = new List<UserRole>();
        }

       

        public string UserName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
           
            
        }
    }
}
