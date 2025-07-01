using MongoDB.Driver;
using Persistence.Core.Models;
using Persistence.Core.Repository;
using System.Linq.Expressions;

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

    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var options = new InsertOneOptions();
        await _collection.InsertOneAsync(entity, options, cancellationToken);
    }

    public async Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _collection.InsertManyAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var filter = Builders<TEntity>.Filter.Eq(p => p.Id, entity.Id);
        await _collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(Builders<TEntity>.Filter.Empty).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _collection.Find(predicate).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _collection.Find(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        if (predicate == null)
            return await _collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty, cancellationToken: cancellationToken);
        return await _collection.CountDocumentsAsync(predicate, cancellationToken: cancellationToken);
    }

    public async Task<List<TEntity>> GetPagedAsync(
        Expression<Func<TEntity, bool>> predicate, 
        int skip, 
        int take, 
        CancellationToken cancellationToken)
    {
        return await _collection.Find(predicate)
            .Skip(skip)
            .Limit(take)
            .ToListAsync(cancellationToken);
    }

    public async Task DeleteManyAsync(
        Expression<Func<TEntity, bool>> predicate, 
        CancellationToken cancellationToken)
    {
        await _collection.DeleteManyAsync(predicate, cancellationToken);
    }
}
