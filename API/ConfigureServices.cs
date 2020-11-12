using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class ConfigureServices
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var optionsBuild = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuild.UseMySQL(config["MySQLConnectionStrings:Default"]);

            services.AddTransient(_ => new ApplicationContext(optionsBuild.Options));

        }

        // Repository wrapper is instantiated as singleton to prevent it from checking whether the database is created on each request
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) => services.AddScoped<RepositoryWrapper>();
    }
}