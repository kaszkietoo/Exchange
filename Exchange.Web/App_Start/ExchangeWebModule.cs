using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using Exchange.Core.Users;
using Abp.Domain.Repositories;
using Exchange.Application.Orders;
using Castle.MicroKernel.Registration;
using Abp.Runtime.Session;
using Exchange.Core;

namespace Exchange.Web
{
    [DependsOn(typeof(ExchangeDataModule), typeof(ExchangeApplicationModule), typeof(ExchangeWebApiModule))]
    public class ExchangeWebModule : AbpModule
    {
        public override void PreInitialize()
        {            
            IocManager.IocContainer.Register(Component.For<IAbpSession, ExchangeSession>().ImplementedBy<ExchangeSession>());       

            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            
            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    ExchangeConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/Exchange")
                    )
                );
            
            Configuration.Navigation.Providers.Add<ExchangeNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());            

            AreaRegistration.RegisterAllAreas();
            RouteConfig.ApplyTokenInspectorHandlerToServicesRoute(RouteTable.Routes, IocManager.IocContainer.Resolve<UserManager>());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }        
    }
}
