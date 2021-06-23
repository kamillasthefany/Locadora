using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Locadora.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseServiceProviderFactory(new AutofacServiceProviderFactory())
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 var port = Environment.GetEnvironmentVariable("PORT");

                 webBuilder.UseStartup<Startup>()
                         .UseUrls("http://*:" + port);
             });
    }
}
