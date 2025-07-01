using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Persistence.Client.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        return services
            .AddMongoDb(connectionString);
    }

    private static IServiceCollection AddMongoDb(this IServiceCollection services, string connectionString)
    {
        services
            .AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(connectionString);
            });

        return services;
    }
}
