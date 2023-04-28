using System.Web.Mvc;
using System.Web.Routing;

namespace FolderStructure
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Folders",
            url: "{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Actions",
            url: "{controller}/{action}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
