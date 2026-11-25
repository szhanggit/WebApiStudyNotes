using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using TXCSwagger5._0.Config;

/*
 https://code-maze.com/swagger-ui-asp-net-core-web-api/
 https://stackoverflow.com/questions/41493130/web-api-how-to-add-a-header-parameter-for-all-api-in-swagger
 */
namespace TXCSwagger5._0.Swagger
{
    public class AddTenantHeaderParameter : IOperationFilter
    {
        private readonly TxcSwaggerConfiguration _swaggerConfiguration;
        public AddTenantHeaderParameter(IOptions<TxcSwaggerConfiguration> configuration)
        {
            _swaggerConfiguration = configuration.Value;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            //if (_swaggerConfiguration.ExcludeTenantHeaders != null && !_swaggerConfiguration.ExcludeTenantHeaders.Contains(operation.Tags[0].Name))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "TenantBasicInfoId",
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema() { Type = "string" },
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "TenantName",
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema() { Type = "string" },
                    Required = false
                });
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "TX2UserName",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "string" },
                Required = false
            });
        }
    }
}
