using MongoDB.Driver;
using OxDistributedDb.Core.Abstractions;
using OxDistributedDb.Core.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OxDistributedDb.Core
{
    /// <summary>Inherit from it if you want to make a generic repo class</summary>
    public class NoSql
    {
        private readonly Dictionary<Type, object> _genericRepos = new Dictionary<Type, object>();
        private static readonly IMongoDbSettings _mongoDbSettings;

        static NoSql()
        {
            try
            {
                var mongoDbSettings = Environment.GetEnvironmentVariable("OXNOSQL_CONNECTIONSTRING");
                _mongoDbSettings = new MongoDbSettings(mongoDbSettings);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Exception message: {ex.Message}. " +
                    $"InnerException: {ex.InnerException}. " +
                    $"InnerExcaptionMessage: {ex.InnerException?.Message}. " +
                    $"StackTrace: {ex.StackTrace}. " +
                    $"DatabaseName: {_mongoDbSettings.DatabaseName}. " +
                    $"ConnectionString: {_mongoDbSettings.ConnectionString}. " +
                    $"Settings: {_mongoDbSettings.Settings}.");
            }
        }

        /// <summary>Pass generic object to register its repo in the NoSql class</summary>
        protected NoSqlGenericRepository<TDocument> Repository<TDocument>() where TDocument : class, IDocument
        {
            if (!_genericRepos.TryGetValue(typeof(TDocument), out object result))
            {
                result = new NoSqlGenericRepository<TDocument>(_mongoDbSettings);
                _genericRepos.Add(typeof(TDocument), result);
            }
            return result as NoSqlGenericRepository<TDocument>;
        }

        /// <summary>Returns all collection names in the current db namespace</summary>
        public async Task<List<string>> GetAllCollectionNamesAsync() => await new MongoClient(_mongoDbSettings.Settings)
                .GetDatabase(_mongoDbSettings.DatabaseName)
                .ListCollectionNames()
                .ToListAsync();
    }
}
