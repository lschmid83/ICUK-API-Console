using System.Web.Mvc;
using System.Web.Routing;

namespace API {

    /// <summary>
    /// Route configuration for the API documentation.
    /// </summary>
    public class RouteConfig {

        /// <summary>
        /// Routes HTTP requests to controller.
        /// </summary>   
        public static void RegisterRoutes(RouteCollection routes) {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",                                            
                url:  "",                                         
                defaults: new { controller = "Home", action = "Index", id = "" } 
            );
            
            routes.MapRoute(
                name: "ApiDocs",
                url: "docs",
                defaults: new { controller = "ApiDoc", action = "Index" }
            );

            routes.MapRoute(
                name: "BroadbandDocs",
                url: "docs/broadband",
                defaults: new { controller = "Broadband", action = "Index" }
            );

            routes.MapRoute(
                name: "HostingDocs",
                url: "docs/hosting",
                defaults: new { controller = "Hosting", action = "Index" }
            );

            routes.MapRoute(
                name: "SmsDocs",
                url: "docs/sms",
                defaults: new { controller = "Sms", action = "Index" }
            );

            routes.MapRoute(
                name: "TelecomDocs",
                url: "docs/telecoms",
                defaults: new { controller = "Telecoms", action = "Index" }
            );

            routes.MapRoute(
                name: "DomainDocs",
                url: "docs/domain",
                defaults: new { controller = "Domain", action = "Index" }
            );

            routes.MapRoute(
                name: "Console",
                url: "docs/console",
                defaults: new { controller = "Console", action = "Index" }
            );
        } 
    }
}
