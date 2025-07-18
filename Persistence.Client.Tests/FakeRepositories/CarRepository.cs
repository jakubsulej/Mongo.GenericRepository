using Core.Abstractions.Repository;
using MongoDB.Driver;
using Persistence.Client.Tests.FakeEntities;
using Persistence.Infrastructure.MongoDb;

namespace Persistence.Client.Tests.FakeRepositories;

public interface ICarRepository : IRepository<CarDocument>;

internal class CarRepository(IMongoClient mongoClient) 
    : MongoRepository<CarDocument>(mongoClient, "FakeDb", "CarsCollection"), ICarRepository;
