using Core.Abstractions.Models;

namespace Persistence.Client.Tests.FakeEntities;

public class CarDocument : IDocument
{
    public required string Id { get; set; }
}
