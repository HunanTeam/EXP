﻿
using Exp.Side.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Exp.Site.Models.Authen.User
{
    public class ChangePwdModel : EntityCommon
    {
        public int Id { get; set; }

        [Display(Name = "用户名")]
        public string LoginName { get; set; }

        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Display(Name = "旧密码")]
        [Required(ErrorMessage = "旧密码不能为空")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "旧密码{2}～{1}个字符")]
        [DataType(DataType.Password)]
        [Remote("CheckPwd", "Profile", ErrorMessage = "旧密码不正确")]
        public string OldLoginPwd { get; set; }

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
    }
}
