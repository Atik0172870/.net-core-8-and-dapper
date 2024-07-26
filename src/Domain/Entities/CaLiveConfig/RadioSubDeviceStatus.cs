using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RadioSubDeviceStatus
{
    [Required]
    [StringLength(20)]
    public string ICCID { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }

    [Required]
    [StringLength(100)]
    public string NLMMACAddress { get; set; } = null!;

    [StringLength(100)]
    public string? IpAddress { get; set; }

    [StringLength(100)]
    public string? NLMVersion { get; set; }

    [StringLength(100)]
    public string? NLMBootLoaderVersion { get; set; }

    public int? OperationMode { get; set; }

    public int? Encryption { get; set; }

    public int? Status { get; set; }

    public string? Reserved { get; set; }

    public int? NLMCh { get; set; }
}
