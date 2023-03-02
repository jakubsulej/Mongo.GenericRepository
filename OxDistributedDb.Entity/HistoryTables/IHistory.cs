using System;

namespace OxDistributedDb.Entity.HistoryTables
{
    public interface IHistory
    {
        Guid HistoryId { get; set; }
        Guid LicenseId { get; set; }
        Guid EditedByUserId { get; set; }
        DateTime CopyCreatedAt { get; set; }
    }
}
