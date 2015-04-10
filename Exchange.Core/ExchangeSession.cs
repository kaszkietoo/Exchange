using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Principal;

namespace Exchange.Core
{
    public class ExchangeSession : IAbpSession, ISingletonDependency
    {
        private IPrincipal _principal;

        public MultiTenancySides MultiTenancySide
        {
            get { return MultiTenancySides.Tenant; }
        }

        public int? TenantId
        {
            get { return null; }
        }

        public long? UserId
        {
            get 
            {                
                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    _principal = Thread.CurrentPrincipal;
                }
                
                if (!Thread.CurrentPrincipal.Identity.IsAuthenticated && _principal != null)
                {
                    Thread.CurrentPrincipal = _principal;
                }

                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    return Thread.CurrentPrincipal.Identity.GetUserId<long>();
                }

                return null;
            }
        }
    }
}
