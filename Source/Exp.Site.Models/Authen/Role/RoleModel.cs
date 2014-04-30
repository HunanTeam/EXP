using Exp.Side.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Exp.Site.Models.Authen.Role
{
	public class RoleModel : EntityCommon
    {
		public RoleModel()
		{
			Search = new SearchModel();
			Enabled = true;
		}

        public int Id { get; set; }

        [Display(Name = "角色名称")]
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "角色名称{2}～{1}个字符")]
        public string Name { get; set; }

        [Display(Name = "角色描述")]
        public string Description { get; set; }

        [Display(Name = "排序")]
		[Required(ErrorMessage = "排序不能为空")]
		[RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        public int OrderSort { get; set; }

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

		public SearchModel Search { get; set; }
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

		[Display(Name = "角色名称")]
		public string Name { get; set; }

		[Display(Name = "是否已激活")]
		public bool Enabled { get; set; }

		public List<SelectListItem> EnabledItems { get; set; }
	}
}
