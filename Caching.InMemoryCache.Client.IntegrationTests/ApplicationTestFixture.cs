using Microsoft.Extensions.DependencyInjection;

namespace Caching.InMemoryCache.Client.IntegrationTests;

public class ApplicationTestFixture : IAsyncLifetime
{
    public ServiceProvider ServiceProvider;

    public ApplicationTestFixture()
    {

    }

    public async Task InitializeAsync()
    {
        var services = new ServiceCollection();
        services.AddInMemoryCacheClient();
        ServiceProvider = services.BuildServiceProvider();
    }

    public async Task DisposeAsync()
    {
        if (ServiceProvider is IAsyncDisposable disposable) await disposable.DisposeAsync();
    }
}

[CollectionDefinition(Name)]
public class ApplicationTestCollection : ICollectionFixture<ApplicationTestFixture>
{
    public const string Name = "Application test collection";
}
