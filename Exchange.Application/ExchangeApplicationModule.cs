using System.Reflection;
using Abp.Modules;

namespace Exchange
{
    [DependsOn(typeof(ExchangeCoreModule))]
    public class ExchangeApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
