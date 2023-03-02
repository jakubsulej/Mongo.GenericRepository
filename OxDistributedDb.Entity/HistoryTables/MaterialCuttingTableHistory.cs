using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class MaterialCuttingTableHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid MaterialId { get; set; }
        public Guid CuttingTableId { get; set; }
        public Guid HistoryId { get; set; }
        public Guid LicenseId { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
