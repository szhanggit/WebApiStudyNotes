using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dispatch.Infrastructure;
using System.Web.Http.Dispatcher;
using System.Reflection;

namespace Dispatch {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //name: "IncludeAction",
            //routeTemplate: "api/today/{action}",
            //defaults: new { controller = "today" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "IncludeAction",
            //    routeTemplate: "api/today/{action}/{day}",
            //    defaults: new
            //    {
            //        controller = "today",
            //        day = RouteParameter.Optional
            //    }
            //);

            config.Routes.MapHttpRoute(
                name: "IncludeAction",
                routeTemplate: "api/today/{action}/{day}",
                defaults: new
                {
                    controller = "today",
                    day = 6
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
