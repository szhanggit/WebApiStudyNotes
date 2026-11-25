using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIClient.Extensions
{
    public static class MediatorExtension
    {
        public static void AddMediatR(this IServiceCollection services)
        {

            services.AddMediatR(typeof(GetImageMediaListQuery).Assembly);
        }
    }
}
