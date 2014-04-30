using System;
using ExpApp.Domain.Models.Base;

namespace ExpApp.Domain.Models.Sys
{
    public class UserRole : Entity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
