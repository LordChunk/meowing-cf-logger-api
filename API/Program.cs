using System;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Starting up app with version: {Assembly.GetEntryAssembly()?.GetName().Version}");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry(o =>
                    {
                        o.Dsn = "https://5b33b0ffed5f4d96be3f0d3635a3f0ac@o272532.ingest.sentry.io/5820135";
                        // When configuring for the first time, to see what the SDK is doing:
                        //o.Debug = true;
                        // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                        // We recommend adjusting this value in production.
                        o.TracesSampleRate = 0.2;
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
