using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class MaterialSettingHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public Guid EditedByUserId { get; set; }
        public Guid LicenseId { get; set; }
        public Guid MaterialId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string BasicType { get; set; }
        public bool Deleted { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
