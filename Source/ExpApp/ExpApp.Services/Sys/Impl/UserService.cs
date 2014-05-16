
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;
using ExpApp.Site.Models.Authen.User;
using ExpApp.Domain.Data.Repositories.Sys;
using ExpApp.Domain.Models.Sys;
using Exp.Core;
using Exp.Core.Data;
using Exp.Tool.Helpers.SecurityHelper;
using System.ComponentModel;
using Exp.Tool.Helpers;
using System.Linq.Expressions;




namespace ExpApp.Services.Sys.Impl
{
    /// <summary>
    /// 服务层实现 —— UserService
    /// </summary>

    public class UserService : CoreServiceBase, IUserService
    {
        public UserService(IRepositoryContext repositoryContext, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
            : base(repositoryContext)
        {
            this.UserRepository = userRepository;
            this.RoleRepository = roleRepository;
            this.UserRoleRepository = userRoleRepository;
        }
        #region 属性


        public IUserRepository UserRepository { get; set; }


        public IRoleRepository RoleRepository { get; set; }


        public IUserRoleRepository UserRoleRepository { get; set; }

        public IQueryable<User> Users
        {
            get { return UserRepository.Entities; }
        }

        public IQueryable<Role> Roles
        {
            get { return RoleRepository.Entities; }
        }

        public IQueryable<UserRole> UserRoles
        {
            get { return UserRoleRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(UserModel model)
        {
            var entity = new User
            {
                LoginName = model.LoginName,
                LoginPwd = DESProvider.EncryptString(model.NewLoginPwd),
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                Enabled = model.Enabled,
                PwdErrorCount = 0,
                LoginCount = 0,
                RegisterTime = DateTime.Now,
                CreateId = model.CreateId,
                CreateBy = model.CreateBy,
                CreateTime = DateTime.Now,
                ModifyId = model.ModifyId,
                ModifyBy = model.ModifyBy,
                ModifyTime = DateTime.Now
            };

            #region Add User Role Mapping

            foreach (int roleId in model.SelectedRoleList)
            {
                if (Roles.Any(t => t.Id == roleId))
                {
                    entity.UserRole.Add(
                        new UserRole()
                        {
                            User = entity,
                            RoleId = roleId,
                            CreateId = model.CreateId,
                            CreateBy = model.CreateBy,
                            CreateTime = DateTime.Now,
                            ModifyId = model.ModifyId,
                            ModifyBy = model.ModifyBy,
                            ModifyTime = DateTime.Now
                        });
                }
            }

            #endregion

            UserRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperationResult Update(User model)
        {
            UserRepository.Update(model);
            return new OperationResult(OperationResultType.Success);
        }

        /// <summary>
        /// 更新基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperationResult Update(UpdateUserModel model)
        {
            var entity = Users.FirstOrDefault(t => t.Id == model.Id);

            entity.FullName = model.FullName;
            entity.Phone = model.Phone;
            entity.Enabled = model.Enabled;
            entity.ModifyId = model.ModifyId;
            entity.ModifyBy = model.ModifyBy;
            entity.ModifyTime = DateTime.Now;

            #region Update User Role Mapping
            var oldRoleIds = entity.UserRole.Where(t => t.IsDeleted == false).Select(t => t.RoleId).ToList();
            var newRoleIds = model.SelectedRoleList.ToList();
            var intersectRoleIds = oldRoleIds.Intersect(newRoleIds).ToList(); // Same Ids
            var removeIds = oldRoleIds.Except(intersectRoleIds).ToList(); // Remove Ids
            var addIds = newRoleIds.Except(intersectRoleIds).ToList(); // Add Ids
            foreach (var removeId in removeIds)
            {
                //更新状态
                var userRole = UserRoles.FirstOrDefault(t => t.UserId == model.Id && t.RoleId == removeId);
                userRole.IsDeleted = true;
                userRole.ModifyId = model.ModifyId;
                userRole.ModifyBy = model.ModifyBy;
                userRole.ModifyTime = DateTime.Now;

                UserRoleRepository.Update(userRole);
            }
            foreach (var addId in addIds)
            {
                var userRole = UserRoles.FirstOrDefault(t => t.UserId == model.Id && t.RoleId == addId);
                // 已有该记录，更新状态
                if (userRole != null)
                {
                    userRole.IsDeleted = false;
                    userRole.ModifyId = model.ModifyId;
                    userRole.ModifyBy = model.ModifyBy;
                    userRole.ModifyTime = DateTime.Now;
                    UserRoleRepository.Update(userRole);
                }
                // 插入
                else
                {
                    entity.UserRole.Add(new UserRole
                    {
                        UserId = model.Id,
                        RoleId = addId,
                        CreateId = model.CreateId,
                        CreateBy = model.CreateBy,
                        CreateTime = DateTime.Now,
                        ModifyId = model.ModifyId,
                        ModifyBy = model.ModifyBy,
                        ModifyTime = DateTime.Now
                    });
                }
            }

            #endregion

            UserRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "更新成功");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperationResult Update(ChangePwdModel model)
        {
            var entity = Users.FirstOrDefault(t => t.Id == model.Id);
            entity.LoginPwd = DESProvider.EncryptString(model.NewLoginPwd);
            entity.ModifyId = model.ModifyId;
            entity.ModifyBy = model.ModifyBy;
            entity.ModifyTime = DateTime.Now;

            UserRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "修改密码成功");
        }

        public OperationResult Delete(UserModel model)
        {
            var entity = Users.FirstOrDefault(t => t.Id == model.Id);
            entity.IsDeleted = true;
            entity.ModifyId = model.ModifyId;
            entity.ModifyBy = model.ModifyBy;
            entity.ModifyTime = DateTime.Now;

            UserRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "删除成功");
        }

        #endregion


        public OperationResult CheckLogin(LoginModel model)
        {
            OperationResult result = new OperationResult(OperationResultType.Warning, "用户名或密码错误");
            var user = this.Users.FirstOrDefault(t => t.LoginName == model.LoginName && t.IsDeleted == false);
            if (user != null)
            {
                if (user.Enabled == false)
                {
                    result = new OperationResult(OperationResultType.Warning, "你的账户已经被禁用");
                }
                else if (DESProvider.DecryptString(user.LoginPwd) == model.LoginPwd)
                {
                    //更新User
                    user.LastLoginTime = DateTime.Now;
                    user.LoginCount += 1;
                    this.Update(user);

                    result = new OperationResult(OperationResultType.Success, "登录成功");
                    result.Result = user;
                }
            }
            return result;
        }

        public IPagedList<UserModel> Search(SearchModel searchModel, string orderBy, ListSortDirection sortDirection, int pageIndex, int pageSize)
        {
            var result = this.UserRepository.Entities.Where(BuildSearchCriteria(searchModel)).OrderBy(orderBy, sortDirection).Select(t =>
                new UserModel
                {
                    Id = t.Id,
                    LoginName = t.LoginName,
                    Email = t.Email,
                    FullName = t.FullName,
                    Phone = t.Phone,
                    Enabled = t.Enabled,
                    RegisterTime = t.RegisterTime,
                    LastLoginTime = t.LastLoginTime
                }
                );

            PagedList<UserModel> list = new PagedList<UserModel>(result, pageIndex, pageSize);
            return list;


        }

        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<User, Boolean>> BuildSearchCriteria(SearchModel searchModel)
        {
            DynamicLambdaHelper<User> bulider = new DynamicLambdaHelper<User>();
            Expression<Func<User, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(searchModel.LoginName))
            {
                var data = searchModel.LoginName;
                Expression<Func<User, Boolean>> tmp = t => t.LoginName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(searchModel.FullName))
            {
                var data = searchModel.FullName.Trim();
                Expression<Func<User, Boolean>> tmp = t => t.FullName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(searchModel.Email))
            {
                var data = searchModel.Email.Trim();
                Expression<Func<User, Boolean>> tmp = t => t.Email.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(searchModel.Phone))
            {
                var data = searchModel.Phone.Trim();
                Expression<Func<User, Boolean>> tmp = t => t.Phone.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            var dataOut = searchModel.Enabled;
            Expression<Func<User, Boolean>> tmpOut = t => t.Enabled == dataOut;
            expr = bulider.BuildQueryAnd(expr, tmpOut);

            if (searchModel.StartTime.HasValue)
            {
                var data = searchModel.StartTime.Value;
                Expression<Func<User, Boolean>> tmp = t => t.RegisterTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (searchModel.EndTime.HasValue)
            {
                var data = searchModel.EndTime.Value.AddDays(1);
                Expression<Func<User, Boolean>> tmp = t => t.RegisterTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<User, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }
    }
}
