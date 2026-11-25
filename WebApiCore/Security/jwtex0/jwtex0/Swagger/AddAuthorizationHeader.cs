using jwtex0.Config;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace jwtex0.Swagger
{
    public class AddAuthorizationHeader : IOperationFilter
    {
        private readonly TxcSwaggerConfiguration _swaggerConfiguration;
        public AddAuthorizationHeader(IOptions<TxcSwaggerConfiguration> configuration)
        {
            _swaggerConfiguration = configuration.Value;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AuthToken",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "string" },
                Required = false
            });
        }
    }
}
