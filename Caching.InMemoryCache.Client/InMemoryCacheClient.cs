using Caching.Client.Abstractions;
using Core.Abstractions.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.InMemoryCache.Client;

public interface IInMemoryCacheClient : ICacheClient;

internal class InMemoryCacheClient(IMemoryCache inMemoryCache) : ICacheClient, IInMemoryCacheClient
{
    private readonly IMemoryCache _inMemoryCache = inMemoryCache;

    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        where T : class, IDocument
    {
        return Task.FromResult(_inMemoryCache.TryGetValue(key, out T? value) ? value : default);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpiration = null, CancellationToken cancellationToken = default)
        where T : class, IDocument
    {
        _inMemoryCache.Set(key, value, absoluteExpiration ?? TimeSpan.FromMinutes(10));
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        _inMemoryCache.Remove(key);
        return Task.CompletedTask;
    }
}
