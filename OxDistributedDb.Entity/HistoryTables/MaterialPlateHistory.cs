using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class MaterialPlateHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public Guid LicenseId { get; set; }
        public Guid MaterialId { get; set; }
        public Guid StandardPlateSizeId { get; set; }
        public bool StandardPlateIsOnStock { get; set; }
        public Guid AlternativePlateSiezeId { get; set; }
        public bool AlternativePlateIsOnStock { get; set; }
        public Guid MaximumPlateSiezeId { get; set; }
        public bool MaximumPlateIsOnStock { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
