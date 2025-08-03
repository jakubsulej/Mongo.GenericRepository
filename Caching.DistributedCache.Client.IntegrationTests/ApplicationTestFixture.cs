using Caching.DistributedCache.Client.Redis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Testcontainers.Redis;

namespace Caching.DistributedCache.Client.IntegrationTests;

public class ApplicationTestFixture : IAsyncLifetime
{
    private readonly RedisContainer _redisContainer;
    public ServiceProvider ServiceProvider;

    public ApplicationTestFixture()
    {
        _redisContainer = new RedisBuilder()
            .WithImage("redis:latest")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _redisContainer.StartAsync();
        var connectionString = _redisContainer.GetConnectionString();
        await ConnectionMultiplexer.ConnectAsync(connectionString);

        var services = new ServiceCollection();
        services.AddRedisCaching(connectionString);
        ServiceProvider = services.BuildServiceProvider();
    }

    public async Task DisposeAsync()
    {
        await _redisContainer.DisposeAsync();
        if (ServiceProvider is IAsyncDisposable disposable) await disposable.DisposeAsync();
    }
}

[CollectionDefinition(Name)]
public class ApplicationTestCollection : ICollectionFixture<ApplicationTestFixture>
{
    public const string Name = "Application test collection";
}
