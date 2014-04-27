using Exp.Core;
using Exp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Data.NHibernate
{
    public interface INHRepositoryContext : IRepositoryContext
    {
        #region Methods
   
        TEntity GetByKey<TEntity, TKey>(TKey key)
            where TEntity :EntityBase<TKey>;

        IQueryable<TEntity> FindAll<TEntity,TKey>()
            where TEntity : EntityBase<TKey>;
     

        #endregion
    }
}
