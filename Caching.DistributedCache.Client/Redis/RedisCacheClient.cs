using Caching.Client.Abstractions;
using Core.Abstractions.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Caching.DistributedCache.Client.Redis;

public interface IRedisCacheClient : ICacheClient;

internal class RedisCacheClient(IConnectionMultiplexer connectionMultiplexer) : ICacheClient, IRedisCacheClient
{
    private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        where T : class, IDocument
    {
        var redisValue = await _database.StringGetAsync(key);
        if (!redisValue.HasValue)
            return default;

        try
        {
            return JsonSerializer.Deserialize<T>(redisValue!);
        }
        catch
        {
            return default;
        }
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? ttl = null, CancellationToken cancellationToken = default)
        where T : class, IDocument
    {
        var serialized = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, serialized, ttl);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        return _database.KeyDeleteAsync(key);
    }
}
