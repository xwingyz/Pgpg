using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Pgpg.EntityFramework.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class PgpgRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PgpgDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PgpgRepositoryBase(IDbContextProvider<PgpgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add your common methods for all repositories
    }
    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="PgpgRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class PgpgRepositoryBase<TEntity> : PgpgRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PgpgRepositoryBase(IDbContextProvider<PgpgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)!!!
    }
    
}