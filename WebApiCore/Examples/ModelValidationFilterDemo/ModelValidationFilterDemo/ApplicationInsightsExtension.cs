using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelValidationFilterDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationFilterDemo
{
    public static class ApplicationInsightsExtension
    {
        public static IServiceCollection AddApplicationInsight(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(configuration.GetValue<string>("ApplicationInsights:InstrumentationKey"));
            services.AddScoped(typeof(ITelemetryLogTrace<>), typeof(TelemetryLogTrace<>));
            //services.AddSingleton<ITelemetryInitializer, MediaTelemetryInitializer>();

            //services.AddApplicationInsightsTelemetryProcessor<AppInsightsHealthCheckFilter>();
            return services;
        }
    }
}
