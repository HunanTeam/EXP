using System;
namespace ExpApp.Domain.Models.Sys
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperateLog:Base.Entity
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public DateTime? LogTime { get; set; }
        public string LoginName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
