using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using OxDistributedDb.Core.Bson;
using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    [BsonCollection]
    public class MaterialHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public int ArticleId { get; set; }
        public string DescriptionShortCode { get; set; }
        public string DescriptionLongCode { get; set; }
        public string Shape { get; set; }
        public string BasicType { get; set; }
        public string Unit { get; set; }
        public Guid MaterialTypeId { get; set; }
        public Guid MarketGroupId { get; set; }
        public bool IsActive { get; set; }
        public Guid LicenseId { get; set; }
        public int? DisplayId { get; set; }
        public bool IsDefault { get; set; }
        public Guid MaterialPlateId { get; set; }
        public bool Deleted { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
