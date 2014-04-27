using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exp.Core.Data
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        protected Repository()
        {
            this.AutoCommit = true;
        }

        public abstract IUnitOfWork UnitOfWork { get; }


        public abstract IQueryable<TEntity> Entities { get; }


        public bool AutoCommit
        {
            get;
            set;
        }

        public abstract int Insert(TEntity entity);


        public abstract int Insert(IEnumerable<TEntity> entities);


        public abstract int Delete(TKey id);


        public abstract int Delete(TEntity entity);


        public abstract int Delete(IEnumerable<TEntity> entities);


        public abstract int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);


        public abstract int Update(TEntity entity);


        public abstract int Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity);


        public abstract TEntity GetByKey(TKey key);

    }
}
