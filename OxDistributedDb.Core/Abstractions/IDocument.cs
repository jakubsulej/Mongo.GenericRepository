using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OxDistributedDb.Core.Abstractions
{
    /// <summary>Interface to be used for every mongo entity</summary>
    public interface IDocument
    {
        /// <summary>Id as default property that every entity must have</summary>
        [BsonId, BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
    }
}
