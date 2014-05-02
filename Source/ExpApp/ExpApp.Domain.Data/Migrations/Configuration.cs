using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Exp.Data;
using ExpApp.Domain.Models.Sys;

 

namespace ExpApp.Domain.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFDbContext context)
        {
            //角色
            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "系统管理员", Description = "开发人员、系统配置人员使用", OrderSort = 1, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Role { Id = 2, Name = "网站管理员", Description = "网站内容管理人员", OrderSort = 2, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now }
            };
            DbSet<Role> roleSet = context.Set<Role>();
            roleSet.AddOrUpdate(t => new { t.Id }, roles.ToArray());
            context.SaveChanges();

            //用户
            var users = new List<User>
            {
                new User { Id = 1, LoginName = "admin", LoginPwd = "8wdJLK8mokI=", FullName="admin", Email = "terrychen@qq.com", Phone ="123456", Enabled = true, IsDeleted = false, PwdErrorCount = 0, LoginCount = 0, RegisterTime = DateTime.Now, LastLoginTime = DateTime.Now, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now }
            };
            DbSet<User> userSet = context.Set<User>();
            userSet.AddOrUpdate(t => new { t.Id }, users.ToArray());
            context.SaveChanges();

            //用户-角色
            var userRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1, IsDeleted = false },
            };
            DbSet<UserRole> userRoleSet = context.Set<UserRole>();
            userRoleSet.AddOrUpdate(t => new { t.UserId }, userRoles.ToArray());
            context.SaveChanges();

            //模块
            var modules = new List<Module>
            {
                new Module { Id = 1, ParentId = null, Name = "权限管理", LinkUrl = null, Area = null, Controller = null, Action = null, Icon = "icon-sitemap", Code = "20", OrderSort = 1, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 2, ParentId = 1, Name = "角色管理", LinkUrl = "Authen/Role/Index", Area = "Authen", Controller = "Role", Action = "Index", Icon = "", Code = "2001", OrderSort = 2, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 3, ParentId = 1, Name = "用户管理", LinkUrl = "Authen/User/Index", Area = "Authen", Controller = "User", Action = "Index", Icon = "", Code = "2002", OrderSort = 3, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 4, ParentId = 1, Name = "模块管理", LinkUrl = "Authen/Module/Index", Area = "Authen", Controller = "Module", Action = "Index", Icon = "", Code = "2003", OrderSort = 4, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 5, ParentId = 1, Name = "权限管理", LinkUrl = "Authen/Permission/Index", Area = "Authen", Controller = "Permission", Action = "Index", Icon = "", Code = "2004", OrderSort = 5, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 6, ParentId = null, Name = "系统应用", LinkUrl = null, Area = null, Controller = null, Action = null, Icon = "icon-cloud", Code = "30", OrderSort = 1, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 7, ParentId = 6, Name = "操作日志管理", LinkUrl = "SysConfig/OperateLog/Index", Area = "SysConfig", Controller = "OperateLog", Action = "Index", Icon = "", Code = "3001", OrderSort = 2, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 8, ParentId = 6, Name = "图标附录", LinkUrl = "SysConfig/Appendix/Icon", Area = "SysConfig", Controller = "Appendix", Action = "Icon", Icon = "", Code = "3002", OrderSort = 3, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 9, ParentId = null, Name = "个人资料", LinkUrl = "Common/Profile/Index", Area = "Common", Controller = "Profile", Action = "Index", Icon = "", Code = "9001", OrderSort = 1, Description = null, IsMenu = false, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now },
                new Module { Id = 10, ParentId = null, Name = "修改密码", LinkUrl = "Common/Profile/ChangePwd", Area = "Common", Controller = "Profile", Action = "Index", Icon = "", Code = "9002", OrderSort = 1, Description = null, IsMenu = false, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now }
            };
            DbSet<Module> moduleSet = context.Set<Module>();
            moduleSet.AddOrUpdate(t => new { t.Id }, modules.ToArray());
            context.SaveChanges();

            //权限
            var permissions = new List<Permission> 
            {
                new Permission { Id = 1, Code = "Index", Name = "浏览", OrderSort = 1, Icon = null, Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 2, Code = "Create", Name = "新增", OrderSort = 2, Icon = "icon-plus", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 3, Code = "Edit", Name = "编辑", OrderSort = 3, Icon = "icon-pencil", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 4, Code = "Delete", Name = "删除", OrderSort = 4, Icon = "icon-remove", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 5, Code = "SetButton", Name = "设置按钮", OrderSort = 5, Icon = "icon-legal", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 6, Code = "SetPermission", Name = "设置权限", OrderSort = 6, Icon = "icon-sitemap", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 7, Code = "ChangePwd", Name = "修改密码", OrderSort = 7, Icon = "icon-key", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new Permission { Id = 8, Code = "DeleteAll", Name = "删除全部", OrderSort = 8, Icon = "icon-trash", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  }
            };
            DbSet<Permission> permissionSet = context.Set<Permission>();
            permissionSet.AddOrUpdate(t => new { t.Id }, permissions.ToArray());
            context.SaveChanges();

            //模块-权限
            var modulePermissions = new List<ModulePermission> 
            {
                new ModulePermission { Id = 1, ModuleId = 2, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 2, ModuleId = 2, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 3, ModuleId = 2, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 4, ModuleId = 2, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 5, ModuleId = 2, PermissionId = 6, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new ModulePermission { Id = 6, ModuleId = 3, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 7, ModuleId = 3, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 8, ModuleId = 3, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 9, ModuleId = 3, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 10, ModuleId = 3, PermissionId = 7, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new ModulePermission { Id = 11, ModuleId = 4, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 12, ModuleId = 4, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 13, ModuleId = 4, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 14, ModuleId = 4, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 15, ModuleId = 4, PermissionId = 5, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new ModulePermission { Id = 16, ModuleId = 5, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 17, ModuleId = 5, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 18, ModuleId = 5, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 19, ModuleId = 5, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new ModulePermission { Id = 20, ModuleId = 7, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 21, ModuleId = 7, PermissionId = 8, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new ModulePermission { Id = 22, ModuleId = 8, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new ModulePermission { Id = 23, ModuleId = 9, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  }
            };

            DbSet<ModulePermission> modulePermissionsSet = context.Set<ModulePermission>();
            modulePermissionsSet.AddOrUpdate(t => new { t.Id }, modulePermissions.ToArray());
            context.SaveChanges();

            //角色-模块-权限
            var roleModulePermissions = new List<RoleModulePermission> 
            {
                 new RoleModulePermission { Id = 1, RoleId = 1, ModuleId = 1, PermissionId = null, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 2, RoleId = 1, ModuleId = 2, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 3, RoleId = 1, ModuleId = 2, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 4, RoleId = 1, ModuleId = 2, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 5, RoleId = 1, ModuleId = 2, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 6, RoleId = 1, ModuleId = 2, PermissionId = 6, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 7, RoleId = 1, ModuleId = 3, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 8, RoleId = 1, ModuleId = 3, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 9, RoleId = 1, ModuleId = 3, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 10, RoleId = 1, ModuleId = 3, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 11, RoleId = 1, ModuleId = 3, PermissionId = 7, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 12, RoleId = 1, ModuleId = 4, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 13, RoleId = 1, ModuleId = 4, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 14, RoleId = 1, ModuleId = 4, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 15, RoleId = 1, ModuleId = 4, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 16, RoleId = 1, ModuleId = 4, PermissionId = 5, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 17, RoleId = 1, ModuleId = 5, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 18, RoleId = 1, ModuleId = 5, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 19, RoleId = 1, ModuleId = 5, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 20, RoleId = 1, ModuleId = 5, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 21, RoleId = 1, ModuleId = 6, PermissionId = null, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 22, RoleId = 1, ModuleId = 7, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 23, RoleId = 1, ModuleId = 7, PermissionId = 8, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

                new RoleModulePermission { Id = 24, RoleId = 1, ModuleId = 8, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
                new RoleModulePermission { Id = 25, RoleId = 1, ModuleId = 9, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  }
            };

            DbSet<RoleModulePermission> roleModulePermissionSet = context.Set<RoleModulePermission>();
            roleModulePermissionSet.AddOrUpdate(t => new { t.Id }, roleModulePermissions.ToArray());
            context.SaveChanges();
        }
    }
}
