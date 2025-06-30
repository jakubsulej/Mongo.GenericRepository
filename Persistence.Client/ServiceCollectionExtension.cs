using Microsoft.Extensions.DependencyInjection;
using Persistence.Infrastructure.DependencyInjection;

namespace Persistence.Client;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string connectionString)
    {
        return services
            .AddInfrastructureServices(connectionString);
    }
}
