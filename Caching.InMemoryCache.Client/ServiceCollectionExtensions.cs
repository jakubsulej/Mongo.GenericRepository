using Microsoft.Extensions.DependencyInjection;

namespace Caching.InMemoryCache.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryCacheClient(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IInMemoryCacheClient, InMemoryCacheClient>();
        return services;
    }
}
