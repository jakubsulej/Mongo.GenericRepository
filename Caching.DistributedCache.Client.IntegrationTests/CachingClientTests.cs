using AutoFixture;
using Caching.DistributedCache.Client.IntegrationTests.FakeEntities;
using Caching.DistributedCache.Client.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.DistributedCache.Client.IntegrationTests;

[Collection(ApplicationTestCollection.Name)]
public class CachingClientTests
{
    private readonly IRedisCacheClient _cacheClient;
    private readonly Fixture _fixture;

    public CachingClientTests(ApplicationTestFixture applicationTestFixture)
    {
        _cacheClient = applicationTestFixture.ServiceProvider.GetRequiredService<IRedisCacheClient>();
        _fixture = new Fixture();
    }

    [Fact]
    public async Task SetAndGetValue_ShouldReturnCachedValue()
    {
        // Arrange
        var fakeEntity = _fixture.Create<HouseDocument>();
        var key = $"{nameof(HouseDocument)}:{fakeEntity.Id}";

        // Act
        await _cacheClient.SetAsync(key, fakeEntity, TimeSpan.FromSeconds(30));
        var actual = await _cacheClient.GetAsync<HouseDocument>(key);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(fakeEntity.Id, actual.Id);
        Assert.Equal(fakeEntity.Area, actual.Area);
        Assert.Equal(fakeEntity.NumberOfRooms, actual.NumberOfRooms);
    }
}
