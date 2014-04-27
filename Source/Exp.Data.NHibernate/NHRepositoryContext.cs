using Exp.Core;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exp.Data.NHibernate
{
    internal static class QueryableExtender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IFutureValue<TResult> ToFutureValue<TSource, TResult>(this IQueryable<TSource> source,
            Expression<Func<IQueryable<TSource>, TResult>> selector)
            where TResult : struct
        {
            var provider = (INhQueryProvider)source.Provider;
            var method = ((MethodCallExpression)selector.Body).Method;
            var expression = Expression.Call(null, method, source.Expression);
            return (IFutureValue<TResult>)provider.ExecuteFuture(expression);
        }
    }
    public class NHRepositoryContext : INHRepositoryContext
    {
        #region Private Fields
        //private readonly DatabaseSessionFactory databaseSessionFactory;
        private ISession session = null;
        private readonly ISessionFactory sessionFactory = null;
        private ITransaction transaction;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>NHibernateContext</c> class.
        /// </summary>
        protected NHRepositoryContext()
        {

        }
        /// <summary>
        /// Initializes a new instance of <c>NHibernateContext</c> class.
        /// </summary>
        [Obsolete("This constructor is obsolete, please use NHibernateContext(ISessionFactory sessionFactory) override instead.")]
        public NHRepositoryContext(Configuration nhibernateConfig)
            : this()
        {
            this.sessionFactory = nhibernateConfig.BuildSessionFactory();
        }

        public NHRepositoryContext(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
        #endregion

        #region Private Methods
        private void EnsureSession()
        {
            if (this.session == null || !this.session.IsOpen)
            {
                this.session = this.sessionFactory.OpenSession();
                this.transaction = this.session.BeginTransaction();
            }
            else
            {
                if (this.transaction == null || !this.transaction.IsActive)
                {
                    this.transaction = this.session.BeginTransaction();
                }
            }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">A <see cref="System.Boolean"/> value which indicates whether
        /// the object should be disposed explicitly.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // The dispose method will no longer be responsible for the commit
                // handling. Since the object container might handle the lifetime
                // of the repository context on the WCF per-request basis, users should
                // handle the commit logic by themselves.
                //if (!committed)
                //    Commit();
                if (transaction != null)
                {
                    transaction.Dispose();
                    transaction = null;
                }
                if (session != null /*&& dbSession.IsOpen*/)
                {
                    //dbSession.Close();
                    session.Dispose();
                    session = null;
                }
                //dbSession.Dispose();
            }
            // base.Dispose(disposing);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Registers a new object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        public void RegisterNew<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            EnsureSession();
            session.Save(entity);
        }
        public void RegisterDeleted<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            EnsureSession();
            session.Delete(entity);
        }
        /// <summary>
        /// Registers a modified object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        public void RegisterModified<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            EnsureSession();
            session.Update(entity);
        }

        #endregion

        #region IUnitOfWork Members


        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        public virtual void Rollback()
        {
            EnsureSession();
            transaction.Rollback();
        }
        public bool IsCommitted
        {
            get
            {
                return transaction != null &&
                    transaction.WasCommitted;
            }
        }

        public int Commit()
        {
            EnsureSession();
            transaction.Commit();
            return 1;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
        #endregion





        public void RegisterModified<TEntity, TKey>(System.Linq.Expressions.Expression<Func<TEntity, object>> propertyExpression, TEntity entity) where TEntity : EntityBase<TKey>
        {

        }
        public void RegisterDeleted<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TKey>
        {

        }
        public void RegisterNew<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TKey>
        {

        }
        public TEntity GetByKey<TEntity, TKey>(TKey key) where TEntity : EntityBase<TKey>
        {
            EnsureSession();
            var result = (TEntity)this.session.Get(typeof(TEntity), key);
            // Use of implicit transactions is discouraged.
            // For more information please refer to: http://www.hibernatingrhinos.com/products/nhprof/learn/alert/DoNotUseImplicitTransactions
            Commit();
            return result;
        }

        public IQueryable<TEntity> FindAll<TEntity,TKey>() where TEntity : EntityBase<TKey>
        {
            EnsureSession();
            IQueryable<TEntity> result = null;
            var query = this.session.Query<TEntity>();
            return query;
        }


        public int Commit(bool validateOnSaveEnabled = true)
        {
            throw new NotImplementedException();
        }
    }
}
