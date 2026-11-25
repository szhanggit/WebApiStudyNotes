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
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);//From then on, only dispatch in Json format.
            config.DependencyResolver = new CustomResolver();
        }
    }
}
