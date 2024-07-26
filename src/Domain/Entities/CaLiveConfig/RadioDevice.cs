using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RadioDevice
{
    [Required]
    [StringLength(20)]
    public string ICCID { get; set; } = null!;

    public int? HostedDomainType { get; set; }

    public int? ThirdPartyHostedDomainType { get; set; }

    [StringLength(100)]
    public string? ThirdPartyHostedUrlIpAddress { get; set; }

    public int? ThirdPartyHostedPortNumber { get; set; }

    public int? RadioAlertType { get; set; }

    public int? DHCPType { get; set; }

    public int? RadioListeningPort { get; set; }

    public int? ProvisionServerDomainType { get; set; }

    [StringLength(100)]
    public string? ProvisionServerUrlIpAddress { get; set; }

    public int? ProvisionServerPortNumber { get; set; }

    public int? PDPContextTimer { get; set; }

    public int? SignalStrength { get; set; }

    public int? RadioCellTowerTimer { get; set; }

    public int? PCSecurityCode { get; set; }

    public int? RadioLockdownTime { get; set; }

    public int? RadioAuthMaxAllowableAttempt { get; set; }

    [StringLength(100)]
    public string? HostedUrlIpAddress { get; set; }

    public int? HostPortNumber { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int NLMAddress { get; set; }
}
