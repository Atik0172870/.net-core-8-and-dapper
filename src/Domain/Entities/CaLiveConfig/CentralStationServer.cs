using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CentralStationServer
{
    [Key]
    public Guid centralStationId { get; set; }

    [Required]
    [StringLength(50)]
    public string centralStationName { get; set; } = null!;

    [Required]
    [StringLength(8)]
    public string accountNumber { get; set; } = null!;

    [StringLength(50)]
    public string? macAddress { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(12)]
    public string? PrimaryCSTelNo { get; set; }

    [StringLength(15)]
    public string? PrimaryIpAddress { get; set; }

    [StringLength(12)]
    public string? BackupCSTelNo { get; set; }

    [StringLength(15)]
    public string? BackupIpAddress { get; set; }

    public int? PrimaryPort { get; set; }

    public int? BackupPort { get; set; }

    public int CompanyId { get; set; }

    public int? PulseFormat { get; set; }

    [StringLength(32)]
    public string? AESKey { get; set; }

    public int? DBounce { get; set; }

    [StringLength(5)]
    public string? DNIS { get; set; }

    public int? ReceiverType { get; set; }

    [StringLength(5)]
    public string? BackupDNIS { get; set; }

    [StringLength(32)]
    public string? BackupAESKey { get; set; }

    public int? BackupReceiverType { get; set; }

    [StringLength(8)]
    public string? BackupAccountNumber { get; set; }

    public int? PrimaryZeroPadding { get; set; }

    public int? BackupZeroPadding { get; set; }

    public int? PrimaryCSType { get; set; }

    public int? BackupCSType { get; set; }

    public int? PollFailTimeout { get; set; }

    public int? PollingRate { get; set; }

    public bool? DisableResending { get; set; }

    public int? CSTestTimer { get; set; }

    public bool? SendCID { get; set; }

    public int? PrimaryStaticKey { get; set; }

    public int? BackupStaticKey { get; set; }

    public int? CentralStationKey { get; set; }
}
