using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Application.Authorization
{
    public class ExchangeAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission("CanTestAppService", new FixedLocalizableString("Can user test"));
            context.CreatePermission("CanTest2", new FixedLocalizableString("Can user test v2"));
        }
    }
}
