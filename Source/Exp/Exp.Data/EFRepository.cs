using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpApp.Core;
using ExpApp.Core.Data;
using System.Data.Entity;


namespace ExpApp.Data
{
    /// <summary>
    ///     EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    public partial class EFRepository<TEntity, TKey> : Repository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private DbSet<TEntity> _entities = null;
        private object _lockObj = new object();
        public EFRepository(IRepositoryContext repositoryContext)
        {
            this.EFContext = repositoryContext as IEFRepositoryContext;

        }
        #region 属性

        /// <summary>
        ///     获取 仓储上下文的实例
        /// </summary>

        public override IUnitOfWork UnitOfWork
        {
            get
            {
                return EFContext as IUnitOfWork;
            }
        }

        public IEFRepositoryContext EFContext { get; private set; }

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public override IQueryable<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    lock (_lockObj)
                    {
                        if (_entities == null)
                        {
                            _entities = EFContext.Set<TEntity, TKey>();
                        }
                    }
                }

                return _entities;
            }
        }

        #endregion

        #region 公共方法

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Insert(TEntity entity)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterNew<TEntity, TKey>(entity);
            return AutoCommit ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Insert(IEnumerable<TEntity> entities)
        {
            PublicHelper.CheckArgument(entities, "entities");
            EFContext.RegisterNew<TEntity, TKey>(entities);
            return AutoCommit ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Delete(TKey id)
        {
            PublicHelper.CheckArgument(id, "id");
            TEntity entity = EFContext.Set<TEntity, TKey>().Find(id);

            return entity != null ? Delete(entity) : 0;
        }

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Delete(TEntity entity)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterDeleted<TEntity, TKey>(entity);
            return AutoCommit ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Delete(IEnumerable<TEntity> entities)
        {
            PublicHelper.CheckArgument(entities, "entities");
            EFContext.RegisterDeleted<TEntity, TKey>(entities);
            return AutoCommit ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            PublicHelper.CheckArgument(predicate, "predicate");
            List<TEntity> entities = EFContext.Set<TEntity, TKey>().Where(predicate).ToList();
            return entities.Count > 0 ? Delete(entities) : 0;
        }

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int Update(TEntity entity)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterModified<TEntity, TKey>(entity);
            return AutoCommit ? EFContext.Commit() : 0;
        }

        /// <summary>
        /// 使用附带新值的实体信息更新指定实体属性的值
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        /// <returns>操作影响的行数</returns>
        public override int Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity)
        {
            throw new NotSupportedException("上下文公用，不支持按需更新功能。");
            PublicHelper.CheckArgument(propertyExpression, "propertyExpression");
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterModified<TEntity, TKey>(propertyExpression, entity);
            if (AutoCommit)
            {
                var dbSet = EFContext.Set<TEntity, TKey>();
                dbSet.Local.Clear();
                var entry = EFContext.DbContext.Entry(entity);
                return EFContext.Commit(false);
            }
            return 0;
        }

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override TEntity GetByKey(TKey key)
        {
            PublicHelper.CheckArgument(key, "key");
            return EFContext.Set<TEntity, TKey>().Find(key);
        }

        #endregion
    }
}