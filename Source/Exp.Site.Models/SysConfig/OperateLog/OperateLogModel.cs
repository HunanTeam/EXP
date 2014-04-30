using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickRMS.Site.Models.SysConfig.OperateLog
{
	public class OperateLogModel
	{
		public OperateLogModel()
		{
			SearchModel = new SearchModel();
		}

		public long Id { get; set; }
		public string Area { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }
		public string IPAddress { get; set; }
		public string Description { get; set; }
		public DateTime? LogTime { get; set; }
		public string LoginName { get; set; }
		public int UserId { get; set; }

		public SearchModel SearchModel { get; set; }
	}

	public class SearchModel
	{
		[Display(Name = "区域")]
		public string Area { get; set; }

		[Display(Name = "控制器")]
		public string Controller { get; set; }

		[Display(Name = "动作")]
		public string Action { get; set; }

		[Display(Name = "IP地址")]
		public string IPAddress { get; set; }

		[Display(Name = "开始日期")]
		[DataType(DataType.DateTime)]
		public DateTime? StartTime { get; set; }

		[Display(Name = "结束日期")]
		[DataType(DataType.DateTime)]
		public DateTime? EndTime { get; set; }

		[Display(Name = "用户名")]
		public string LoginName { get; set; }
	}
}
