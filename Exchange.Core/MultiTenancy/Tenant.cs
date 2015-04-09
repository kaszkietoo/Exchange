using Abp.MultiTenancy;
using Exchange.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {
    }
}
