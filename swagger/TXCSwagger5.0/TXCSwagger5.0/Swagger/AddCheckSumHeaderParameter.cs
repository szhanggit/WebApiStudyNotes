using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using TXCSwagger5._0.Config;

namespace TXCSwagger5._0.Swagger
{
    public class AddCheckSumHeaderParameter : IOperationFilter
    {
        private readonly TxcSwaggerConfiguration _swaggerConfiguration;

        public AddCheckSumHeaderParameter(IOptions<TxcSwaggerConfiguration> configuration)
        {
            _swaggerConfiguration = configuration.Value;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            if (_swaggerConfiguration.ExcludeCheckSumHeaders != null && !_swaggerConfiguration.ExcludeCheckSumHeaders.Contains(operation.Tags[0].Name))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "checksum",
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema() { Type = "string" },
                    Required = false
                });
            }

        }
    }
}
