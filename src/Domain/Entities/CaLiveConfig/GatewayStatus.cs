using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GatewayStatus
{
    public int Comport { get; set; }

    [MaxLength(50)]
    public string? MACAddress { get; set; }

    [MaxLength(50)]
    public string? IPAddress { get; set; }

    [MaxLength(50)]
    public string? Version { get; set; }

    [MaxLength(150)]
    public string? Status { get; set; }

    public int? LockCount { get; set; }

    public int? Cluster { get; set; }

    public bool? HasRepeaters { get; set; }

    public int? RepeaterCount { get; set; }

    public int? GroupNo { get; set; }

    public DateTime? LastUpdated { get; set; }

    public int CompanyId { get; set; }

    public int ComPortAddress { get; set; }

    public bool IsComFailureReported { get; set; }
}
