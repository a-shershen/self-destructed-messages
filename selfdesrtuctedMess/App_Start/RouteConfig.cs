using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace selfdestructedMess
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ReadMessageRoute",
                url: "{link}",
                defaults: new { controller = "Home", action = "ReadMessage" }
            );

            routes.MapRoute(
                name: "DefaultWithouAction",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "404-PageNotFound",
                "{*url}",
                new { controller = "Home", action = "PageNotFound" }
                );
        }
    }
}
