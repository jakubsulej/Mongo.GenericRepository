using MongoDB.Driver;
using Persistence.Client.Tests.FakeEntities;
using Persistence.Infrastructure.MongoDb;

namespace Persistence.Client.Tests.FakeRepositories;

public interface ICarRepository
{
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
    Task<CarDocument?> GetByIdAsync(string id, CancellationToken cancellationToken);
}

internal class CarRepository(IMongoClient mongoClient) 
    : MongoRepository<CarDocument>(mongoClient, "FakeDb", "CarsCollection"), ICarRepository;
