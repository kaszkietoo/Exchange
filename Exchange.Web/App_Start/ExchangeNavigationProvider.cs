using Abp.Application.Navigation;
using Abp.Localization;

namespace Exchange.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class ExchangeNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Start",
                        new LocalizableString("HomePage", ExchangeConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "/App/Main/images/home.svg"
                        ))
                .AddItem(
                    new MenuItemDefinition(
                        "ReportFreight",
                        new LocalizableString("ReportFreight", ExchangeConsts.LocalizationSourceName),
                        url: "#/freight/add",
                        icon: "/App/Main/images/freight.svg"
                        ))
                .AddItem(
                    new MenuItemDefinition(
                        "SearchFreights",
                        new LocalizableString("SearchFreights", ExchangeConsts.LocalizationSourceName),
                        url: "#/freight/search",
                        icon: "/App/Main/images/freights.svg"
                        ))
                .AddItem(
                    new MenuItemDefinition(
                        "ReportTruck",
                        new LocalizableString("ReportTruck", ExchangeConsts.LocalizationSourceName),
                        url: "#/truck/add",
                        icon: "/App/Main/images/truck.svg"
                        ))                
                .AddItem(
                    new MenuItemDefinition(
                        "SearchTrucks",
                        new LocalizableString("SearchTrucks", ExchangeConsts.LocalizationSourceName),
                        url: "#/truck/search",
                        icon: "/App/Main/images/trucks.svg"
                        ))
                .AddItem(
                    new MenuItemDefinition(
                        "MyOffers",
                        new LocalizableString("MyOffers", ExchangeConsts.LocalizationSourceName),
                        url: "#/offers",
                        icon: "/App/Main/images/offers.svg"
                        ));
        }
    }
}
