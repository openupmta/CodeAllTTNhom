using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace coderush
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "TTCSDL",
                url: "",
                defaults: new { controller = "group_role", action = "Index", id = UrlParameter.Optional }).DataTokens.Add("area", "TTNhom_QLNS");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Dashboardv1", id = UrlParameter.Optional }
            );
        }
    }
}
