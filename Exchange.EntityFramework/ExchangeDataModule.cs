using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Exchange.EntityFramework;

namespace Exchange
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(ExchangeCoreModule))]
    public class ExchangeDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<ExchangeDbContext>(null);
        }
    }
}
