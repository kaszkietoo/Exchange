using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace Exchange
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ExchangeApplicationModule))]
    public class ExchangeWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ExchangeApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
