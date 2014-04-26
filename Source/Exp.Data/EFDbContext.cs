
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

        //   public IEnumerable<IEntityMapper> EntityMappers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //if (EntityMappers == null)
            //{
            //    return;
            //}

            //foreach (var mapper in EntityMappers)
            //{
            //    mapper.RegistTo(modelBuilder.Configurations);
            //}

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
         .Where(type => !String.IsNullOrEmpty(type.Namespace))
         .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());



            base.OnModelCreating(modelBuilder);
        }
    }
}