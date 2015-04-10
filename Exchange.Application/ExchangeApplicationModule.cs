using System.Reflection;
using Abp.Modules;
using Exchange.Application.Authorization;

namespace Exchange
{
    [DependsOn(typeof(ExchangeCoreModule))]
    public class ExchangeApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Authorization.Providers.Add<ExchangeAuthorizationProvider>();
        }
    }
}
