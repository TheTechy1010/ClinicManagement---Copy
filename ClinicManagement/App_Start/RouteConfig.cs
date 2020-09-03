using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClinicManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DefaultPage",
                url: "{controller}/{action}/{page:int}",
                defaults: new { controller = "Patients", action = "Index", page=1 }
            );
            routes.MapRoute(
                name: "DefaultSearch",
                url: "{controller}/{action}/{searchString}",
                defaults: new { controller = "Patients", action = "Index", searchString = "" }
            );
            routes.MapRoute(
                name: "patientRoute",
                url: "{controller}/{action}/{sortOrder}/{seatchString}/{page}",
                defaults: new { controller = "Patients",action="Index",sortOrder=UrlParameter.Optional,searchString=UrlParameter.Optional, page = 1 }
            );
        }
    }
}
