using Data.Repositories.Common;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class ConfigureServices
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) => services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}