using Exp.Core;
using Exp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exp.Data.NHibernate
{
    public class NHRepository<TEntity, TKey> : Repository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly INHRepositoryContext _nhRepositoryContext;
        public NHRepository(IRepositoryContext repositoryContext)
        {
            _nhRepositoryContext = repositoryContext as INHRepositoryContext;
        }
        public override IUnitOfWork UnitOfWork
        {
            get { return _nhRepositoryContext; }
        }
        public INHRepositoryContext NHContext
        {
            get
            {
                return _nhRepositoryContext;
            }
        }
        public override IQueryable<TEntity> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public override int Insert(TEntity entity)
        {

            this.NHContext.RegisterNew<TEntity, TKey>(entity);
            return 1;

        }

        public override int Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public override int Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public override int Delete(TEntity entity)
        {
            this.NHContext.RegisterDeleted<TEntity, TKey>(entity);
            return 1;
        }

        public override int Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override int Update(TEntity entity)
        {
            this.NHContext.RegisterModified<TEntity, TKey>(entity);
        }

        public override int Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override TEntity GetByKey(TKey key)
        {
            return this.NHContext.GetByKey<TEntity, TKey>(key);
        }
    }
}
