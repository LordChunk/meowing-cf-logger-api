using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sentry;
using Sentry.AspNetCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gitVer = Assembly
                .GetEntryAssembly()!
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            Console.WriteLine($"App assembly version: {Assembly.GetEntryAssembly()?.GetName().Version}");
            Console.WriteLine($"App version with commit hash: {gitVer}");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json")
                .Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry(o =>
                    {
                        o.Dsn = configuration.GetValue<string>("SentryDsn");
                        
                        // When configuring for the first time, to see what the SDK is doing:
                        //o.Debug = true;
                        // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                        // We recommend adjusting this value in production.
                        o.TracesSampleRate = 0.2;
                        o.AddEntityFramework();
                        o.MinimumBreadcrumbLevel = LogLevel.Debug;
                    });

                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
