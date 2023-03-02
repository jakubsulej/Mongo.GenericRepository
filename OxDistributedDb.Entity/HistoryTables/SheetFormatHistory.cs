using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class SheetFormatHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public Guid LicenseId { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
