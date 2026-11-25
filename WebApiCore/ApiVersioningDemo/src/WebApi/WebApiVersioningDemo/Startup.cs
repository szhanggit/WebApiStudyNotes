using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVersioningDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            //configure API versionining
            services.AddApiVersioning(x =>
            {
                //Specifies defaulr version of APIs. ApiVersion type is a part of Microsoft.AspNetCore.Versioning NuGet.
                x.DefaultApiVersion = new ApiVersion(1,0);
                //if client does not specify version in API, use default API. If this is false and version is not specified by client, API throws UnsupportedApiVersionException.
                x.AssumeDefaultVersionWhenUnspecified = true;
                //return the API version in response header
                x.ReportApiVersions = true;
                //declare header parameter for Header based versioning. Otherwise comment it
                x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
