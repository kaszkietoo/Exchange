using Abp.Authorization.Users;
using Exchange.Core.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Users
{
    public class User : AbpUser<Tenant, User>
    {
    }
}
