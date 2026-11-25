using System.Web.Http;
using ExampleApp.Infrastructure;
using System.Net.Http.Formatting;
using System;

namespace ExampleApp {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            config.DependencyResolver = new NinjectResolver();

            //config.Services.Replace(typeof(IContentNegotiator), 
            //  new CustomNegotiator());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new ProductFormatter());
        }
    }
}
