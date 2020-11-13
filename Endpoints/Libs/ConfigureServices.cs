using Libs.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EndPointLibs
{
    public static class ConfigureServices
    {
        // Repository wrapper is instantiated as singleton to prevent it from checking whether the database is created on each request
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) => services.AddTransient<IRepositoryWrapper, RepositoryWrapperEndpoint>();

        public static void ConfigureMqClient(this IServiceCollection services)
        {
            //services.AddTransient<>()
        }
    }
}