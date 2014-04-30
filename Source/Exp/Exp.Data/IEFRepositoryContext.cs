using Exp.Core;
using Exp.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Exp.Data
{
    public interface IEFRepositoryContext : IRepositoryContext
    {
        DbContext DbContext { get; }
        DbSet<TEntity> Set<TEntity, TKey>() where TEntity : EntityBase<TKey>;

        int Commit(bool validateOnSaveEnabled = true);
    }
}
