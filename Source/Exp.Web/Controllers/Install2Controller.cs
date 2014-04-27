using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp.Web.Controllers
{
    public class Install2Controller : Controller
    {
        //
        // GET: /Install2/

        public ActionResult Index()
        {
            string conStr = "server = localhost;user id =root password =; database =exp_01";
            conStr = createMySqlConnectionString("localhost", "exp_01", "root", "", 1000);
            if (!mySqlDatabaseExists(conStr))
            {
                createMySqlDatabase(conStr);
            }

            return View();
        }
        private bool mySqlDatabaseExists(string connectionString)
        {
            try
            {
                //just try to connect
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string createMySqlDatabase(string connectionString)
        {
            try
            {
                //parse database name
                var builder = new MySqlConnectionStringBuilder(connectionString);
                var databaseName = builder.Database;
                //now create connection string to 'master' dabatase. It always exists.
                builder.Database = string.Empty; // = "master";
                var masterCatalogConnectionString = builder.ToString();
                string query = string.Format("CREATE DATABASE {0} COLLATE utf8_unicode_ci", databaseName);

                using (var conn = new MySqlConnection(masterCatalogConnectionString))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Format("An error occured when creating database: {0}", ex.Message);
            }
        }
        private string createMySqlConnectionString(string serverName, string databaseName, string userName, string password, UInt32 timeout = 0)
        {
            var builder = new MySqlConnectionStringBuilder();
            builder.Server = serverName;
            builder.Database = databaseName.ToLower();
            builder.UserID = userName;
            builder.Password = password;
            builder.PersistSecurityInfo = false;
            builder.AllowUserVariables = true;
            builder.DefaultCommandTimeout = 30000;

            builder.ConnectionTimeout = timeout;
            return builder.ConnectionString;
        }
    }
}
