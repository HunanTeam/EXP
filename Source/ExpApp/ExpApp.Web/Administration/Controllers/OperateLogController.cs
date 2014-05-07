using Exp.Core;
using Exp.Tool.Helpers;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services.Sys;
using ExpApp.Site.Common.Models;
using ExpApp.Site.Models.SysConfig.OperateLog;
using ExpApp.Web.Framework.Common;
using ExpApp.Web.Framework.Extension.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ExpApp.Admin.Controllers
{
    public class OperateLogController : AdminBaseController
    {

        public OperateLogController(IOperateLogService operateLogService)
        {
            this.OperateLogService = operateLogService;
        }
        #region 属性
    
        public IOperateLogService OperateLogService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
            var model = new OperateLogModel();
            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            int total = OperateLogService.OperateLogs.Count(t => t.IsDeleted == false);

            //构建查询表达式
            var expr = BuildSearchCriteria();

            var filterResult = OperateLogService.OperateLogs.Where(expr).Select(t => new OperateLogModel
            {
                LogTime = t.LogTime,
                Area = t.Area,
                Controller = t.Controller,
                Action = t.Action,
                Description = t.Description,
                IPAddress = t.IPAddress,
                LoginName = t.LoginName

            }).OrderByDescending(t => t.LogTime).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
								 c.LogTime.ToString(),
								 c.Area,
								 c.Controller,
								 c.Action,
								 c.Description,
								 c.IPAddress,
								 c.LoginName
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iDisplayStart = param.iDisplayStart,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<OperateLog, Boolean>> BuildSearchCriteria()
        {
            DynamicLambdaHelper<OperateLog> bulider = new DynamicLambdaHelper<OperateLog>();
            Expression<Func<OperateLog, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["Area"]))
            {
                var data = Request["Area"].Trim();
                Expression<Func<OperateLog, Boolean>> tmp = t => t.Area.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Controller"]))
            {
                var data = Request["Controller"].Trim();
                Expression<Func<OperateLog, Boolean>> tmp = t => t.Controller.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Action"]))
            {
                var data = Request["Action"].Trim();
                Expression<Func<OperateLog, Boolean>> tmp = t => t.Action.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["IPAddress"]))
            {
                var data = Request["IPAddress"].Trim();
                Expression<Func<OperateLog, Boolean>> tmp = t => t.IPAddress.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["LoginName"]))
            {
                var data = Request["LoginName"].Trim();
                Expression<Func<OperateLog, Boolean>> tmp = t => t.LoginName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<OperateLog, Boolean>> tmp = t => t.LogTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<OperateLog, Boolean>> tmp = t => t.LogTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<OperateLog, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

        public ActionResult DeleteAll()
        {
            OperationResult result = OperateLogService.Delete();
            return Json(result);
        }
    }
}