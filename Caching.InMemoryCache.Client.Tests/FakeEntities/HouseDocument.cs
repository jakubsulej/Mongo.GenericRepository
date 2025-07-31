using Core.Abstractions.Models;

namespace Caching.InMemoryCache.Client.Tests.FakeEntities;

internal class HouseDocument : IDocument
{
    public required string Id { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Area { get; set; }
}
