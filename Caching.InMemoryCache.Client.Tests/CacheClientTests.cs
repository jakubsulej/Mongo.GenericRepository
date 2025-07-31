using Caching.Client.Abstractions;
using Caching.InMemoryCache.Client.Tests.FakeEntities;
using FakeItEasy;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.InMemoryCache.Client.Tests;

public class CacheClientTests
{
    private readonly ICacheClient _cacheClient;

    public CacheClientTests()
    {
        var memoryCacheFake = A.Fake<IMemoryCache>();
        _cacheClient = new InMemoryCacheClient(memoryCacheFake);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnExpectedDocument()
    {
        //Arrange
        var house = new HouseDocument
        {
            Id = Guid.NewGuid().ToString(),
            NumberOfRooms = 1,
            Area = 200
        };
        var key = $"{nameof(HouseDocument)}-{house.Id}";

        //Act
        var result = await _cacheClient.GetAsync<HouseDocument>(key);

        //Assert
        Assert.Null(result);
    }
}