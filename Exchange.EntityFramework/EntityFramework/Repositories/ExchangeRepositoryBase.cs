using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Exchange.EntityFramework.Repositories
{
    public abstract class ExchangeRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ExchangeDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ExchangeRepositoryBase(IDbContextProvider<ExchangeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ExchangeRepositoryBase<TEntity> : ExchangeRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ExchangeRepositoryBase(IDbContextProvider<ExchangeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
