using Exp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExpApp.Domain.Data
{
    public class EntityMapperProvider : IEntityMapperProvider
    {
        private IEnumerable<IEntityMapper> _entityMappers = null;
        public EntityMapperProvider()
        {

        }
        public IEnumerable<IEntityMapper> EntityMappers
        {
            get
            {
                if (_entityMappers == null)
                {
                    _entityMappers = Get();
                }
                return _entityMappers;
            }
        }

        private IEnumerable<IEntityMapper> Get()
        {
            IList<IEntityMapper> list = new List<IEntityMapper>();
            
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
         .Where(type => !String.IsNullOrEmpty(type.Namespace))
         .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                IEntityMapper configurationInstance = (IEntityMapper)Activator.CreateInstance(type);
                list.Add(configurationInstance);
            }

            return list;
        }
    }
}
