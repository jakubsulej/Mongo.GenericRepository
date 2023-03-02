using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using OxDistributedDb.Core.Bson;
using System;

namespace OxDistributedDb.Entity.TestLogs
{
    [BsonCollection]
    public class QuotePriceTest : IDocument
    {
        public ObjectId Id { get; set; }
        public Guid LicenseId { get; set; }
        public string FileName { get; set; }
        public string UiPrice { get; set; }
        public string DbPrice { get; set; }
        public DateTime TestTime { get; set; }
        public string TestDuration { get; set; }
        public string Url { get; set; }
    }
}
