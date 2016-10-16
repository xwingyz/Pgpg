using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Pgpg.EntityFramework.Repositories
{
    public abstract class PgpgRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PgpgDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PgpgRepositoryBase(IDbContextProvider<PgpgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PgpgRepositoryBase<TEntity> : PgpgRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PgpgRepositoryBase(IDbContextProvider<PgpgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
