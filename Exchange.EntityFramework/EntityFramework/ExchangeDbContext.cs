using Abp.EntityFramework;
using Abp.Zero.EntityFramework;
using Exchange.Core.Authorization;
using Exchange.Core.MultiTenancy;
using Exchange.Core.Users;

namespace Exchange.EntityFramework
{
    public class ExchangeDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public ExchangeDbContext()
            : base("Default")
        {

        }
        
        public ExchangeDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
