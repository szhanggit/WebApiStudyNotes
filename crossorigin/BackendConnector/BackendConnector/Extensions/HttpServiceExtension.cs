using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackendConnector.Extensions
{
    public static class HttpServiceExtension
    {
        public static IServiceCollection AddHttpService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            //services.AddScoped<IHttpService, HttpService>();
            return services;
        }
    }
}
