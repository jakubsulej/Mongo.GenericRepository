using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Caching.DistributedCache.Client.Redis;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisCaching(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(connectionString));
        services.AddSingleton<IRedisCacheClient, RedisCacheClient>();
        return services;
    }
}

