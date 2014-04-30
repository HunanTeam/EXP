using System;
using System.Collections.Generic;
using ExpApp.Domain.Models.Base;

namespace ExpApp.Domain.Models.System
{
    /// <summary>
    /// 标识系统模块
    /// </summary>
    public class Module:Entity
    {
        public Module()
        {
            this.ChildModule = new List<Module>();
            this.ModulePermission = new List<ModulePermission>();
            this.RoleModulePermission = new List<RoleModulePermission>();
        }

        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
        public int OrderSort { get; set; }
        public string Description { get; set; }
        public bool IsMenu { get; set; }
        public bool Enabled { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }

        public virtual Module ParentModule { get; set; }
        public virtual ICollection<Module> ChildModule { get; set; }
        public virtual ICollection<ModulePermission> ModulePermission { get; set; }
        public virtual ICollection<RoleModulePermission> RoleModulePermission { get; set; }
    }
}
