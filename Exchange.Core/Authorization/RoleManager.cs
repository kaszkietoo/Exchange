using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using Exchange.Core.MultiTenancy;
using Exchange.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Authorization
{
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(
            RoleStore store, 
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            IUnitOfWorkManager unitOfWorkManager)
            : base(store, permissionManager, roleManagementConfig, unitOfWorkManager)
        {
        }
    }
}
