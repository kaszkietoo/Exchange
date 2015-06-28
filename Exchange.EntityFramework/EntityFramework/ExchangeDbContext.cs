using Abp.EntityFramework;
using Abp.Zero.EntityFramework;
using Exchange.Core.Authorization;
using Exchange.Core.Entities;
using Exchange.Core.MultiTenancy;
using Exchange.Core.Users;
using System.Collections.Generic;
using System.Data.Entity;

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

        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<Offer> Offers { get; set; }
    }
}
