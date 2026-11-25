using Common.Services.HttpService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIClient.Extensions
{
    public static class HttpServiceExtension
    {
        public static IServiceCollection AddHttpService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddScoped<IHttpService, HttpService>();
            return services;
        }
    }
}
