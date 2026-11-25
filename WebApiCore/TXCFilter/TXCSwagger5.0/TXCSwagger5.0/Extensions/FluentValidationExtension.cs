using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TXCSwagger5._0.Validators;

namespace TXCSwagger5._0.Extensions
{
    public static class FluentValidationExtension
    {
        public static void AddFluentValidation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<ExpirySchemeByProductIdQueryValidator>();
            services.AddFluentValidationAutoValidation();
        }
    }
}
