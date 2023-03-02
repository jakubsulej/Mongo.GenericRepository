using MongoDB.Driver;
using OxDistributedDb.Core.Abstractions;
using System;
using System.Linq;

namespace OxDistributedDb.Core.Settings
{
    /// <summary>Object that contains database name and connection string properties</summary>
    public sealed class MongoDbSettings : IMongoDbSettings
    {
        internal MongoDbSettings(string environmentVariable)
        {
            try
            {
                DatabaseName = GetVariableByName(environmentVariable, "DatabaseName");
                ConnectionString = GetVariableByName(environmentVariable, "ConnectionString");
            }
            catch (Exception)
            {
                throw;
            } 
        }

        /// <summary>Name of the currently used database namespace</summary>
        public string DatabaseName { get; }

        /// <summary>Connection string to currently set database</summary>
        public string ConnectionString { get; }

        /// <summary>MongoClientsSettings needed to connect to azure mongo cosmos. It is using ssl protocol Tls12</summary>
        public MongoClientSettings Settings
        {
            get
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                return settings;
            }
        }

        private string GetVariableByName(string environmentVariable, string variableName)
        {
            if (string.IsNullOrEmpty(environmentVariable))
                throw new Exception(
                    "OXNOSQL_CONNECTIONSTRING is not provided in environment variables. " +
                    "Please specify when working on localhost in your cmd: " +
                    "'SETX OXNOSQL_CONNECTIONSTRING DatabaseName=OxQuote;ConnectionString=mongodb://localhost:27017'");

            return environmentVariable.Split(";").FirstOrDefault(x => x.Contains(variableName)).Split($"{variableName}=")[1];
        }
    }
}
