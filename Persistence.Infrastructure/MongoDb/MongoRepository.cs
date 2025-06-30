using MongoDB.Driver;
using Persistence.Core.Models;
using Persistence.Core.Repository;

namespace Persistence.Infrastructure.MongoDb;

public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, IDocument
{
    private readonly IMongoCollection<TEntity> _collection;

    public MongoRepository(IMongoClient mongoClient, string databaseName, string collectionName)
    {
        var database = mongoClient.GetDatabase(databaseName);
        _collection = database.GetCollection<TEntity>(collectionName);
    }

    public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
        await _collection.DeleteOneAsync(filter, cancellationToken);
    }
}
