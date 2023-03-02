using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OxDistributedDb.Core.Abstractions;
using System;
using System.Text.Json.Serialization;

namespace OxDistributedDb.Entity.HistoryTables
{
    public class OperationHistory : IDocument, IHistory
    {
        public ObjectId Id { get; set; }
        public Guid HistoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public decimal? FixedCostPerHour { get; set; }
        public decimal? VariableCostPerHour { get; set; }
        public decimal? FuelCost { get; set; }
        public decimal? PreparationTime { get; set; }
        public Guid LicenseId { get; set; }
        public bool Deleted { get; set; }
        public Guid EditedByUserId { get; set; }
        public DateTime CopyCreatedAt { get; set; }
    }
}
