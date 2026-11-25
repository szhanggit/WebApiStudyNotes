using TXCMediatR.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TXCMediatR.Queries;

namespace TXCMediatR.Extensions
{
    public static class MediatorExtension
    {
        public static void ConfigureMediateR(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddMediatR(typeof(InsertSKUBackupCommand).Assembly);
        }
    }
}
