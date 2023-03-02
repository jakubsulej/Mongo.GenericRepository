using MongoDB.Bson;
using MongoDB.Driver;
using OxDistributedDb.Core.Abstractions;
using OxDistributedDb.Core.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OxDistributedDb.Core
{
    /// <summary>Contains all the methods to be used for crud operations in mongo</summary>
    public sealed class NoSqlGenericRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        internal NoSqlGenericRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.Settings).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        /// <summary>
        /// Returns IQuerable object, but it is a not very effective way of gather data from mongodb database.
        /// </summary>
        public IQueryable<TDocument> GetQuerable(
            Expression<Func<TDocument, bool>> filter = null) => filter != null ? _collection.AsQueryable().Where(filter) : _collection.AsQueryable();

        /// <summary>
        /// This method uses our previously prepared attribute and gets documents collection by type of document provided in parameter 
        /// (ex. when we pass Person as the parameter, this method will return “people” as a result).
        /// </summary>
        private string GetCollectionName(Type documentType) => ((BsonCollectionAttribute)documentType
            .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
            .FirstOrDefault())?.CollectionName ?? documentType.Name;

        /// <summary>
        /// Those methods allows us to filter data by sending expressions in parameters. 
        /// This works similar to LINQ, but operations are performed on database, so it’s much faster than doing it later in code-side. 
        /// </summary>
        public IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filter) 
            => _collection.Find(filter).ToEnumerable();

        /// <summary>
        /// those methods allows us to filter data by sending expressions in parameters. 
        /// This works similar to LINQ, but operations are performed on database, so it’s much faster than doing it later in code-side. 
        /// Extra parameter called projectionExpression is useful, when you want to get only some fields, rather than full objects from filtered results.
        /// </summary>
        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filter,
            Expression<Func<TDocument, TProjected>> projectionExpression) =>
            _collection.Find(filter).Project(projectionExpression).ToEnumerable();

        /// <summary>
        /// Similar to FirstOrDefault in LINQ, gets first value that matches an expression.
        /// </summary>
        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression) 
            => await _collection.Find(filterExpression).FirstOrDefaultAsync();

        /// <summary>
        /// Similar to FirstOrDefault in LINQ, gets first value that matches an expression.
        /// </summary>
        public async Task<TDocument> FindByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        /// <summary>
        /// That method simply inserts only one record to existing database.
        /// </summary>
        public async Task InsertOneAsync(TDocument document) 
            => await _collection.InsertOneAsync(document);

        /// <summary>
        /// That method simply inserts collection of records to existing database.
        /// </summary>
        public async Task InsertManyAsync(ICollection<TDocument> documents) 
            => await _collection.InsertManyAsync(documents);

        /// <summary>
        /// That method simply replaces a record in existing database. Can be used insted.
        /// </summary>
        public async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        /// <summary>
        /// That method simply deletes one record from existing database.
        /// </summary>
        public async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression) 
            => await _collection.FindOneAndDeleteAsync(filterExpression);

        /// <summary>
        /// That method simply deletes one record by id in existing database.
        /// </summary>
        public async Task DeleteByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            await _collection.FindOneAndDeleteAsync(filter);
        }

        /// <summary>
        /// That method simply deletes collection of records in existing database.
        /// </summary>
        public async Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression) 
            => await _collection.DeleteManyAsync(filterExpression);
    }
}
