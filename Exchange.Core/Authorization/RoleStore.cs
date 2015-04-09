using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Exchange.Core.MultiTenancy;
using Exchange.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Authorization
{
    public class RoleStore : AbpRoleStore<Tenant, Role, User>
    {
        public RoleStore(
            IRepository<Role> roleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                rolePermissionSettingRepository)
        {
            
        }
    }
}
