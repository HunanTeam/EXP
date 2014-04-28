
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.Linq;
namespace Exp.Data
{
    
    public class EFDbContext : DbContext
    {
         
        public EFDbContext()
            : base("default") { }

        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public EFDbContext(DbConnection existingConnection)
            : base(existingConnection, true) { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
         .Where(type => !String.IsNullOrEmpty(type.Namespace))
         .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }




            base.OnModelCreating(modelBuilder);
        }
    }
}