using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        // for REST
                        options.ListenAnyIP(8001, o => o.Protocols =
                            HttpProtocols.Http1AndHttp2);

                        // for gRPC
                        options.ListenAnyIP(9001, o => o.Protocols =
                            HttpProtocols.Http2);

                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
