using System;
using System.Configuration;
using System.Data.Entity;
using Exp.Core;

namespace Exp.Data
{
 
    public class EFRepositoryContext : RepositoryContextBase
    {
        /// <summary>
        ///     获取 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get
            {
                bool secondCachingEnabled = ConfigurationManager.AppSettings["EntityFrameworkCachingEnabled"].CastTo(false);
                return secondCachingEnabled ? EFCachingDbContext.Value : EFDbContext.Value;
            }
        }

        
        private Lazy<EFDbContext> EFDbContext { get; set; }

        
        private Lazy<EFCachingDbContext> EFCachingDbContext { get; set; }
    }
}