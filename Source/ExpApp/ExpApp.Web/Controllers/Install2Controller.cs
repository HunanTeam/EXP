using Exp.Data;
using ExpApp.Domain.Models.Sys;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using Exp.Core;
using Exp.Core.Data;
namespace ExpApp.Web.Controllers
{
    public class Install2Controller : Controller
    {
        IRepository<Role, int> _roleRepository;
        IRepository<User, int> _userRepository;
        IRepository<UserRole, int> _userRoleRepository;
        IRepository<Module, int> _moduleRepository;
        IRepository<Permission, int> _permissionRepository;
        IRepository<ModulePermission, int> _modulePermissionRepository;
        IRepository<RoleModulePermission, int> _roleModulePermissionRepository;

        public Install2Controller(IRepository<Role, int> roleRepository, IRepository<User, int> userRepository
            , IRepository<UserRole, int> userRoleRepository, IRepository<Module, int> moduleRepository
            , IRepository<Permission, int> permissionRepository
             , IRepository<ModulePermission, int> modulePermissionRepository
             , IRepository<RoleModulePermission, int> roleModulePermissionRepository
            )
        {

            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _permissionRepository = permissionRepository;
            _moduleRepository = moduleRepository;
            _modulePermissionRepository = modulePermissionRepository;
            _roleModulePermissionRepository = roleModulePermissionRepository;
        }
        //
        // GET: /Install2/

        public ActionResult Index()
        {
            string conStr = "server = localhost;user id =root password =; database =exp_01";
            conStr = createMySqlConnectionString("localhost", "exp_01", "root", "", 1000);
            if (!mySqlDatabaseExists(conStr))
            {
                createMySqlDatabase(conStr);
            }

            return View();
        }

        public ActionResult Init()
        {

            var connectionString = Ioc.Get<DataSettings>().DataConnectionString;
            Seed( );
            return View();
        }

        protected void Seed()
        {
            _roleRepository.AutoCommit = false;
            //角色
            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "系统管理员", Description = "开发人员、系统配置人员使用", OrderSort = 1, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Role { Id = 2, Name = "网站管理员", Description = "网站内容管理人员", OrderSort = 2, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now }
            };
            _roleRepository.Insert(roles);

            //用户
            var users = new List<User>
            {
                new User { Id = 1, LoginName = "admin", LoginPwd = "8wdJLK8mokI=", FullName="admin", Email = "terrychen@qq.com", Phone ="123456", Enabled = true, IsDeleted = false, PwdErrorCount = 0, LoginCount = 0, RegisterTime = DateTime.Now, LastLoginTime = DateTime.Now, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now }
            };

            _userRepository.Insert(users);

            //用户-角色
            var userRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1, IsDeleted = false },
            };
            _userRoleRepository.Insert(userRoles);

            //模块
            var modules = new List<Module>
            {
                new Module { Id = 1, ParentId = null, Name = "权限管理", LinkUrl = null, Area = null, Controller = null, Action = null, Icon = "icon-sitemap", Code = "20", OrderSort = 1, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 2, ParentId = 1, Name = "角色管理", LinkUrl = "Admin/Role/Index", Area = "Admin", Controller = "Role", Action = "Index", Icon = "", Code = "2001", OrderSort = 2, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 3, ParentId = 1, Name = "用户管理", LinkUrl = "Admin/User/Index", Area = "Admin", Controller = "User", Action = "Index", Icon = "", Code = "2002", OrderSort = 3, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 4, ParentId = 1, Name = "模块管理", LinkUrl = "Admin/Module/Index", Area = "Admin", Controller = "Module", Action = "Index", Icon = "", Code = "2003", OrderSort = 4, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 5, ParentId = 1, Name = "权限管理", LinkUrl = "Admin/Permission/Index", Area = "Admin", Controller = "Permission", Action = "Index", Icon = "", Code = "2004", OrderSort = 5, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 6, ParentId = null, Name = "系统应用", LinkUrl = null, Area = null, Controller = null, Action = null, Icon = "icon-cloud", Code = "30", OrderSort = 1, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 7, ParentId = 6, Name = "操作日志管理", LinkUrl = "Admin/OperateLog/Index", Area = "Admin", Controller = "OperateLog", Action = "Index", Icon = "", Code = "3001", OrderSort = 2, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 8, ParentId = 6, Name = "图标附录", LinkUrl = "Admin/Appendix/Icon", Area = "Admin", Controller = "Appendix", Action = "Icon", Icon = "", Code = "3002", OrderSort = 3, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
                new Module { Id = 9, ParentId = null, Name = "个人资料", LinkUrl = "Admin/Profile/Index", Area = "Admin", Controller = "Profile", Action = "Index", Icon = "", Code = "9001", OrderSort = 1, Description = null, IsMenu = false, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now },
                new Module { Id = 10, ParentId = null, Name = "修改密码", LinkUrl = "Admin/Profile/ChangePwd", Area = "Admin", Controller = "Profile", Action = "Index", Icon = "", Code = "9002", OrderSort = 1, Description = null, IsMenu = false, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now }
            };
            _moduleRepository.Insert(modules);

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
            _permissionRepository.Insert(permissions);
               
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

            _modulePermissionRepository.Insert(modulePermissions);

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

            _roleModulePermissionRepository.Insert(roleModulePermissions);

            _roleRepository.UnitOfWork.Commit();
        }
        private bool mySqlDatabaseExists(string connectionString)
        {
            try
            {
                //just try to connect
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string createMySqlDatabase(string connectionString)
        {
            try
            {
                //parse database name
                var builder = new MySqlConnectionStringBuilder(connectionString);
                var databaseName = builder.Database;
                //now create connection string to 'master' dabatase. It always exists.
                builder.Database = string.Empty; // = "master";
                var masterCatalogConnectionString = builder.ToString();
                string query = string.Format("CREATE DATABASE {0} COLLATE utf8_unicode_ci", databaseName);

                using (var conn = new MySqlConnection(masterCatalogConnectionString))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Format("An error occured when creating database: {0}", ex.Message);
            }
        }
        private string createMySqlConnectionString(string serverName, string databaseName, string userName, string password, UInt32 timeout = 0)
        {
            var builder = new MySqlConnectionStringBuilder();
            builder.Server = serverName;
            builder.Database = databaseName.ToLower();
            builder.UserID = userName;
            builder.Password = password;
            builder.PersistSecurityInfo = false;
            builder.AllowUserVariables = true;
            builder.DefaultCommandTimeout = 30000;

            builder.ConnectionTimeout = timeout;
            return builder.ConnectionString;
        }
    }
}
