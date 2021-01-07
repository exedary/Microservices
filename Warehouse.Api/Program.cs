using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

namespace Warehouse.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            if (!int.TryParse(Environment.GetEnvironmentVariable("PORT"), out var port))
            {
                port = 8081;
            }
            return Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseStartup<Startup>();
                                webBuilder.ConfigureKestrel(x => x.Listen(IPAddress.Any, port));
                            });
        }
    }
}
