using Exchange.Core.Users;
using Exchange.Web.Security;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exchange.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");            

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public static void ApplyTokenInspectorHandlerToServicesRoute(RouteCollection routes, UserManager userManager)
        {
            var servicesRoute = routes[0];
            string servicesRouteUrl = (string)servicesRoute.GetType().GetProperty("Url").GetValue(servicesRoute);
            var tokenInspector = new TokenInspector(userManager) 
            { 
                InnerHandler = new HttpControllerDispatcher(GlobalConfiguration.Configuration) 
            };

            routes.Clear();            

            routes.MapHttpRoute(
                name: "ServicesRoute",
                routeTemplate: servicesRouteUrl,
                defaults: null,
                constraints: null,
                handler: tokenInspector
                );            
        }
    }
}
