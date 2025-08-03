using Core.Abstractions.Models;

namespace Caching.DistributedCache.Client.IntegrationTests.FakeEntities;

public class HouseDocument : IDocument
{
    public required string Id { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Area { get; set; }
}
