using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class MachineHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public Guid LicenseId { get; set; }
        public string Name { get; set; }
        public string OperationType { get; set; }
        public bool Deleted { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
