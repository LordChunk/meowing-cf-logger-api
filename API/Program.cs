using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Sentry;

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

            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
            CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
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
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                });
        }
    }
}
