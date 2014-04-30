using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpApp.Site.Models.Authen.RoleModulePermission
{
	public class RoleSelectedPermissionModel
	{
		public RoleSelectedPermissionModel()
		{
			this.HeaderPermissionList = new List<PermissionModel>();
			this.ModulePermissionDataList = new List<ModulePermissionModel>();
		}

		public int RoleId { get; set; }
		public string OldModulePermission { get; set; }
		public string NewModulePermission { get; set; }

		public List<PermissionModel> HeaderPermissionList { get; set; }
		public List<ModulePermissionModel> ModulePermissionDataList { get; set; }
	}

	public class ModulePermissionModel
	{
		public ModulePermissionModel()
		{
			this.PermissionDataList = new List<PermissionModel>();
		}

		public int ModuleId { get; set; }

		public int? ParentId { get; set; }

		public string ModuleName { get; set; }

		public string Code { get; set; }

		public bool Selected { get; set; }

		public List<PermissionModel> PermissionDataList { get; set; }
	}

	public class PermissionModel
	{
		public int PermissionId { get; set; }

		public string PermissionName { get; set; }

		public int OrderSort { get; set; }

		public bool Selected { get; set; }

		public bool Enabled { get; set; }

	}
}
