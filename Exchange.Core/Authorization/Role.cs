using Abp.Authorization.Roles;
using Exchange.Core.MultiTenancy;
using Exchange.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Authorization
{
    public class Role : AbpRole<Tenant, User>
    {
    }
}
