using Core.Abstractions.Models;

namespace Persistence.Client.Tests.FakeEntities;

internal class CarDocument : IDocument
{
    public required string Id { get; set; }
}
