using Exp.Core.Data;
using Exp.Data;
using ExpApp.Domain.Data.Migrations;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ExpApp.Domain.Data
{
    public class MySqlDataProvider : IDataProvider
    {
        public void InitConnectionFactory()
        {
            var connectionFactory = new MySqlConnectionFactory();
            //TODO fix compilation warning (below)
#pragma warning disable 0618
            Database.DefaultConnectionFactory = connectionFactory;
        }

        public void SetDatabaseInitializer()
        {
            var initializer =new MigrateDatabaseToLatestVersion<EFDbContext,Configuration>();

            Database.SetInitializer(initializer);
        }

        public virtual void InitDatabase()
        {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }
        /// <summary>
        /// A value indicating whether this data provider supports stored procedures
        /// </summary>
        public virtual bool StoredProceduredSupported
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a support database parameter object (used by stored procedures)
        /// </summary>
        /// <returns>Parameter</returns>
        public virtual DbParameter GetParameter()
        {
            return new MySqlParameter();
        }
    }
}
