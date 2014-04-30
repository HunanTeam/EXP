using Exp.Core.Data;
using Exp.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpApp.Web.Controllers
{
    public class InstallController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Exp_01;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=sa123;MultipleActiveResultSets=True";
            string collation=string.Empty;
             CreateDatabase(connectionString, collation);
            var dataProviderInstance = EngineContext.Current.Resolve<BaseDataProviderManager>().LoadDataProvider();
            dataProviderInstance.InitDatabase();

            return View();   
        }

            [NonAction]
        protected string CreateDatabase(string connectionString, string collation)
        {
            try
            {
                //parse database name
                var builder = new SqlConnectionStringBuilder(connectionString);
                var databaseName = builder.InitialCatalog;
                //now create connection string to 'master' dabatase. It always exists.
                builder.InitialCatalog = "master";
                var masterCatalogConnectionString = builder.ToString();
                string query = string.Format("CREATE DATABASE [{0}]", databaseName);
                if (!String.IsNullOrWhiteSpace(collation))
                    query = string.Format("{0} COLLATE {1}", query, collation);
                using (var conn = new SqlConnection(masterCatalogConnectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();  
                    } 
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
