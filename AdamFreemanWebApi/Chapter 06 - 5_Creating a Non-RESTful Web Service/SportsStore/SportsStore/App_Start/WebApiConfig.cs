using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SportsStore.Infrastructure;

namespace SportsStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "OrdersRoute",
                routeTemplate: "nonrest/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);//From then on, only dispatch in Json format.
            config.DependencyResolver = new CustomResolver();

            /*There is a circular reference in the relationship between the Order and OrderLine classes: an Order has a collection
            of OrderLine objects, each of which contains a reference back to the Order. This is a problem for the standard
            serialization process, which will report an error when it finds such a loop.*/
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling 
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
