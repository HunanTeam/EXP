using ExpApp.Site.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
 

namespace ExpApp.Site.Models.Authen.Permission
{
	public class PermissionModel : EntityCommon
    {
		public PermissionModel()
		{
			Enabled = true;
		}

        public int Id { get; set; }

        [Display(Name = "编码")]
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "编码{2}～{1}个字符")]
        public string Code { get; set; }

		[Display(Name = "名称")]
		[Required(ErrorMessage = "名称不能为空")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "名称{2}～{1}个字符")]
		public string Name { get; set; }

        [Display(Name = "图标")]
        public string Icon { get; set; }

        public string Area { get; set; }
        public string Controller { get; set; }

        [Display(Name = "按钮函数")]
        [Required(ErrorMessage = "按钮函数不能为空")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "按钮函数{2}～{1}个字符")]
        public string Action { get; set; }

        [Display(Name = "排序")]
        [Required(ErrorMessage = "排序不能为空")]
		[RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        public int OrderSort { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

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
    }

	public class ButtonModel
	{
		public ButtonModel()
		{
			ButtonList = new List<KeyValueModel>();
			SelectedButtonList = new List<int>();
		}

		public int ModuleId { get; set; }

		public string ModuleName{ get;set; }

		public ICollection<KeyValueModel> ButtonList { get; set; }

		[KeyValue(DisplayProperty = "ButtonList")]
        public ICollection<int> SelectedButtonList { get; set; }
	}
}
