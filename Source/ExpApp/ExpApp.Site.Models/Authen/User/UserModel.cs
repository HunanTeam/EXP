using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

 
using System.Web.Mvc;
using ExpApp.Site.Common.Models;
 

namespace ExpApp.Site.Models.Authen.User
{
	public class UserModel : EntityCommon
    {
        public UserModel() 
        {
            Search = new SearchModel();
            RoleList = new List<KeyValueModel>();
            SelectedRoleList = new List<int>();
			Enabled = true;
        }

        public SearchModel Search { get; set; }

        #region UserItem
        public int Id { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "用户名{2}～{1}个字符")]
		[Remote("CheckLoginName", "User", ErrorMessage = "用户名已存在")]
        public string LoginName { get; set; }

        [Display(Name = "新密码")]
        [Required(ErrorMessage = "新密码不能为空")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "新密码{2}～{1}个字符")]
        [DataType(DataType.Password)]
        public string NewLoginPwd { get; set; }

        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "新密码确认不能为空")]
        [DataType(DataType.Password)]
        //      [System.ComponentModel.DataAnnotations.Compare("NewLoginPwd", ErrorMessage = "新密码和确认密码不一致")](Net4.5才有)
       [Compare("NewLoginPwd", ErrorMessage = "新密码和确认密码不一致")]
        public string NewLoginPwdConfirm { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "姓名{2}～{1}个字符")]
        public string FullName { get; set; }

        [Display(Name = "电子邮件")]
        [Required(ErrorMessage = "电子邮件不能为空")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}", ErrorMessage = "电子邮件格式不正确")]
        public string Email { get; set; }

        [Display(Name = "电话号码")]
        public string Phone { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

		public string EnabledText
		{
			get
			{
				if (Enabled == true)
				{
					return "是";
				}
				else
				{
					return "否";
				}
			}
			set { }
		}

        public int PwdErrorCount { get; set; }

        public int LoginCount { get; set; }

        [Display(Name = "注册时间")]
        public DateTime? RegisterTime { get; set; }

		[Display(Name = "最后登陆时间")]
        public DateTime? LastLoginTime { get; set; }

        public ICollection<KeyValueModel> RoleList { get; set; }

        [KeyValue(DisplayProperty = "RoleList")]
        public ICollection<int> SelectedRoleList { get; set; }

        #endregion
    }

    public class SearchModel
    {
        public SearchModel()
        {
            EnabledItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- 请选择 ---", Value = "-1", Selected = true }, 
                new SelectListItem { Text = "是", Value = "1" }, 
                new SelectListItem { Text = "否", Value = "0" }
            };
        }

        [Display(Name = "用户名")]
        public string LoginName { get; set; }

        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Display(Name = "电话号码")]
        public string Phone { get; set; }

        [Display(Name = "是否已激活")]
        public bool Enabled { get; set; }

		[Display(Name = "注册开始日期")]
		[DataType(DataType.DateTime)]
		public DateTime? StartTime { get; set; }

		[Display(Name = "注册结束日期")]
		[DataType(DataType.DateTime)]
		public DateTime? EndTime { get; set; }

        public List<SelectListItem> EnabledItems { get; set; }
    }

    
}
