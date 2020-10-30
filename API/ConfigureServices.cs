using Data.Repositories.Common;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class ConfigureServices
    {
        // Repository wrapper is instantiated as singleton to prevent it from checking whether the database is created on each request
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) => services.AddSingleton<IRepositoryWrapper, RepositoryWrapper>();
    }
}