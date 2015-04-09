using System.Reflection;
using Abp.Modules;

namespace Exchange
{
    public class ExchangeCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
