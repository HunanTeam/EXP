using ExpApp.Side.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace ExpApp.Site.Models.Authen.User
{
	public class UpdateUserModel : EntityCommon
    {
        public UpdateUserModel()
        {
            RoleList = new List<KeyValueModel>();
            SelectedRoleList = new List<int>();
			Enabled = true;
        }

        public int Id { get; set; }

        [Display(Name = "用户名")]
        public string LoginName { get; set; }

        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Display(Name = "电话号码")]
        public string Phone { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "姓名{2}～{1}个字符")]
        public string FullName { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Display(Name = "注册时间")]
        public DateTime? RegisterTime { get; set; }

        [Display(Name = "最后登陆时间")]
        public DateTime? LastLoginTime { get; set; }

        public ICollection<KeyValueModel> RoleList { get; set; }

        [KeyValue(DisplayProperty = "RoleList")]
        public ICollection<int> SelectedRoleList { get; set; }
    }
}
