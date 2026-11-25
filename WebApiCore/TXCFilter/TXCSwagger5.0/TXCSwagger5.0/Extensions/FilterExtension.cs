using Microsoft.Extensions.DependencyInjection;
using TXCSwagger5._0.Filters;

namespace TXCSwagger5._0.Extensions
{
    public static class FilterExtension
    {
        public static IServiceCollection AddFilter(this IServiceCollection services)
        {
            services.AddScoped<TenantFilter>();
            services.AddScoped<TenantIdFilter>();
            services.AddScoped<ModelValidationResultFilter>();
            services.AddScoped<UserNameFilter>();
            services.AddScoped<CheckSumFilter>();
            return services;
        }
    }
}
