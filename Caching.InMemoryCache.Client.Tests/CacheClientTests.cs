using Caching.Client.Abstractions;
using FakeItEasy;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.InMemoryCache.Client.Tests;

public class CacheClientTests
{
    private readonly ICacheClient _cacheClient;

    public CacheClientTests(ICachingClient<IInMemoryCacheClient> cachingClient)
    {
        var memoryCacheFake = A.Fake<IMemoryCache>();
        _cacheClient = new InMemoryCacheClient(memoryCacheFake);
    }

    [Fact]
    public async Task Test1()
    {
        //await _cacheClient.SetAsync<IDocument>("");
    }
}