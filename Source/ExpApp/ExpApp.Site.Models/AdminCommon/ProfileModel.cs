using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpApp.Site.Models.AdminCommon
{
	public class ProfileModel
	{
		public int Id { get; set; }
		public string LoginName { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int LoginCount { get; set; }
		public DateTime? RegisterTime { get; set; }
		public DateTime? LastLoginTime { get; set; }
	}
}
