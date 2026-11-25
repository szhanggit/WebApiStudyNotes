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

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new SayHelloAttribute { Message = "Global Filter" });
        }
    }
}
