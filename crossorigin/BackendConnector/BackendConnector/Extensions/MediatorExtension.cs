using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services.Command.TxProduct;

namespace BackendConnector.Extensions
{
    public static class MediatorExtension
    {
        public static void AddMediatR(this IServiceCollection services)
        {

            services.AddMediatR(typeof(CreateExternalPropertyListCommand).Assembly);
        }
    }
}
