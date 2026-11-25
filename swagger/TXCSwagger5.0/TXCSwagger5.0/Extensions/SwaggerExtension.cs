using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using TXCSwagger5._0.Config;
using TXCSwagger5._0.Swagger;

namespace TXCSwagger5._0.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TxcSwaggerConfiguration>(options => configuration.GetSection("SwaggerConfiguration").Bind(options));
            services.AddSwaggerGen(c =>
            {
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TXCSwagger5.0", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization do not add 'BEARER' ",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });

                c.OperationFilter<AddTenantHeaderParameter>();
                c.OperationFilter<AddCheckSumHeaderParameter>();
            });

            return services;
        }
    }
}
