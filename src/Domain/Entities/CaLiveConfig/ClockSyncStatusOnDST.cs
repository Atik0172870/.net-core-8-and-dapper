using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ClockSyncStatusOnDST
{
    [Key]
    public int Comport { get; set; }

    [Key]
    public int ComportAddress { get; set; }

    [Key]
    public int CompanyId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? LastUpdate { get; set; }

    public bool? SyncSuccess { get; set; }
}
