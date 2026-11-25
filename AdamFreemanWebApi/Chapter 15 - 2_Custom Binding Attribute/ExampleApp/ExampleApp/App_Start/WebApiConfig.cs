using System.Web.Http;
using ExampleApp.Infrastructure;
using System.Web.Http.ValueProviders;
using System.Net.Http.Headers;

namespace ExampleApp {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            config.DependencyResolver = new NinjectResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Binding Example Route",
                routeTemplate: "api/{controller}/{action}/{first}/{second}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
