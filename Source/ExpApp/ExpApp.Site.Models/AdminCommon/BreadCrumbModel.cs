﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpApp.Site.Models.AdminCommon
{
	public class BreadCrumbNavModel
	{
		public BreadCrumbNavModel()
		{
			BreadCrumbList = new List<BreadCrumbModel>();
		}

		public bool IsOnlyIndex { get; set; }
		public string CurrentName { get; set; }

		public List<BreadCrumbModel> BreadCrumbList { get; set; }
	}

	public class BreadCrumbModel
	{
		public bool IsIndex { get; set; }
		public bool IsParent { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
	}
}
