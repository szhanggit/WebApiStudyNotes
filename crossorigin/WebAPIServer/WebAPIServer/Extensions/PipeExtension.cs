using Infrastructure.Pipes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServer.Extensions
{
    public static class PipeExtension
    {
        public static void AddPipe(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
        }
    }
}
