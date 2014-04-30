using System;
using ExpApp.Domain.Models.Base;

namespace ExpApp.Domain.Models.System
{
    public class RoleModulePermission : Entity
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int? PermissionId { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }

        public virtual Role Role { get; set; }
        public virtual Module Module { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
