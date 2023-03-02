using MongoDB.Driver;

namespace OxDistributedDb.Core.Abstractions
{
    /// <summary>Object that contains database name and connection string properties</summary>
    public interface IMongoDbSettings
    {
        /// <summary>Name of the currently used database namespace</summary>
        string ConnectionString { get; }
        /// <summary>Connection string to currently set database</summary>
        string DatabaseName { get; }
        /// <summary>MongoClientsSettings needed to connect to azure mongo cosmos</summary>
        MongoClientSettings Settings { get; }
    }
}