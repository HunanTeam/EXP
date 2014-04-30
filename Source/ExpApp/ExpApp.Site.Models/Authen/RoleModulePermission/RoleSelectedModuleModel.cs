 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpApp.Site.Models.Authen.RoleModulePermission
{

	/// <summary>
	/// 选中菜单
	/// </summary>
	public class RoleSelectedModuleModel
	{
		public RoleSelectedModuleModel()
		{
			this.ModuleDataList = new List<ModuleModel>();
		}

		public int RoleId { get; set; }
		public string RoleName { get; set; }
        public string oldModulePermission { get; set; }

		public List<ModuleModel> ModuleDataList { get; set; }
	}


	public class ModuleModel
	{
		public int ModuleId { get;set; }
		public int? ParentId { get; set; }
		public string ModuleName { get; set; }
		public string Code { get; set; }
		public bool Selected { get; set; }
	}
}
