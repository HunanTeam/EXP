using Exp.Core;
using Exp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Data.NHibernate
{
    public class NHRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly INHRepositoryContext _nhRepositoryContext;
        public NHRepository(IRepositoryContext repositoryContext)
        {
            _nhRepositoryContext = repositoryContext as INHRepositoryContext;
        }
        public IUnitOfWork UnitOfWork
        {
            get { return _nhRepositoryContext; }
        }

        public IQueryable<TEntity> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public int Insert(TEntity entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(TKey id, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int Update(System.Linq.Expressions.Expression<Func<TEntity, object>> propertyExpression, TEntity entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByKey(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}
