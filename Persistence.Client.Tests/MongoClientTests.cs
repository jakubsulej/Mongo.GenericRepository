using FakeItEasy;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence.Client.Tests.FakeEntities;
using Persistence.Client.Tests.FakeRepositories;

namespace Persistence.Client.Tests;

public class MongoClientTests
{
    private readonly IMongoDatabase _fakeMongoDatabase;
    private readonly IMongoClient _mongoDbClient;
    private readonly ICarRepository _carRepository;

    public MongoClientTests()
    {
        _fakeMongoDatabase = A.Fake<IMongoDatabase>();
        _mongoDbClient = A.Fake<IMongoClient>();
        _carRepository = new CarRepository(_mongoDbClient);
    }

    [Fact]
    public async Task CheckIfCustomRepoCanUseGenericOne_ShouldInjectAllFakeServicesAndClients()
    {
        //Arrange
        var id = new ObjectId().ToString();
        var carCollection = A.Fake<IMongoCollection<CarDocument>>();

        A.CallTo(() => _fakeMongoDatabase.GetCollection<CarDocument>("CarsCollection", A<MongoCollectionSettings>._)).Returns(carCollection);
        A.CallTo(() => _mongoDbClient.GetDatabase("FakeDb", A<MongoDatabaseSettings>._)).Returns(_fakeMongoDatabase);

        //Act
        var carDocument = await _carRepository.GetByIdAsync(id, default);

        //Assert
        Assert.Null(carDocument);
    }
}