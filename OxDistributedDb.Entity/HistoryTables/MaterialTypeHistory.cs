using MongoDB.Bson;
using OxDistributedDb.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class MaterialTypeHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public Guid LicenseId { get; set; }
        public string TypeCode { get; set; }
        public string BasicType { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
