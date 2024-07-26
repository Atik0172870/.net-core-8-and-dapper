using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RadioStatus
{
    [Required]
    [StringLength(20)]
    public string ICCID { get; set; } = null!;

    public int? Medium { get; set; }

    public int? NOC { get; set; }

    public int? LastRespStatus { get; set; }

    public int? SignalStrength { get; set; }

    public int? DHCPType { get; set; }

    public int? RadioListeningPort { get; set; }

    [StringLength(100)]
    public string? HostedUrlIpAddress { get; set; }

    public int? HostPortNumber { get; set; }

    public DateTime? RadioRealTimeClock { get; set; }

    public int? RadioCheckinType { get; set; }

    public int? MicroSystemStatus { get; set; }

    public int? MicroConfigFlag { get; set; }

    [StringLength(100)]
    public string? MicroRebootReason { get; set; }

    [StringLength(100)]
    public string? RadioFirmwareVersion { get; set; }

    [StringLength(50)]
    public string? RadioId { get; set; }

    [StringLength(20)]
    public string? RadioIpAddress { get; set; }

    [StringLength(100)]
    public string? RadioTroubleDiagonsticLedStatus { get; set; }

    [StringLength(100)]
    public string? LocalNetworkStatus { get; set; }

    public int? RadioToDeviceEncryption { get; set; }

    public int? RadioToHostEncryption { get; set; }

    [StringLength(100)]
    public string? ValidDeviceMACTable { get; set; }

    [StringLength(100)]
    public string? RadioModemFirmwareVersion { get; set; }

    public int? Src { get; set; }

    public int? Des { get; set; }

    public int? FirmwareDownloadState { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public bool? DisabledDeviceCommunication { get; set; }

    public int? Flags { get; set; }

    public string? Reserve { get; set; }

    [StringLength(100)]
    public string? MACAddress { get; set; }

    [StringLength(100)]
    public string? RadioToDeviceStaticIP { get; set; }

    public int? RadioToDeviceStaticPort { get; set; }

    [StringLength(100)]
    public string? RadioToDeviceNetworkMask { get; set; }

    [StringLength(100)]
    public string? RadioToDeviceNetworkGateway { get; set; }

    [StringLength(100)]
    public string? Device1StaticIP { get; set; }

    [StringLength(100)]
    public string? Device2StaticIP { get; set; }

    [StringLength(100)]
    public string? Device3StaticIP { get; set; }

    [StringLength(100)]
    public string? Device4StaticIP { get; set; }

    [StringLength(100)]
    public string? Device5StaticIP { get; set; }

    [StringLength(100)]
    public string? Device6StaticIP { get; set; }

    public int? EthernetWIFIOperationMode { get; set; }

    [StringLength(100)]
    public string? WIFIRouterSSID { get; set; }

    [StringLength(100)]
    public string? WIFIRouterPassword { get; set; }

    public int? WIFIRouterSecurityMode { get; set; }

    public short? WPA2Algorithm { get; set; }

    public int? ThirdPartyHostedDomainType { get; set; }

    [StringLength(100)]
    public string? ThirdPartyHostedUrlIpAddress { get; set; }

    public int? ThirdPartyHostedPortNumber { get; set; }

    public int? ProvisionServerDomainType { get; set; }

    [StringLength(100)]
    public string? ProvisionServerUrlIpAddress { get; set; }

    public int? ProvisionServerPortNumber { get; set; }

    public int? RadioAlertType { get; set; }

    public int? PDPContextTimer { get; set; }

    public int? SignalStrengthInterval { get; set; }

    public int? RadioCellTowerTimer { get; set; }

    public int? PCSecurityCode { get; set; }

    public int? RadioLockdownTime { get; set; }

    public int? RadioAuthMaxAllowableAttempt { get; set; }

    [StringLength(1000)]
    public string? RadioWirelessNetworkInfo { get; set; }

    public string? PayloadReserve { get; set; }

    public string? CellTower { get; set; }

    public string? LastServedCellTowerInfo { get; set; }

    public string? RadioOutageReportInfo { get; set; }

    [Required]
    public bool IsComFailureReported { get; set; }

    [Required]
    public int TimeZoneOffset { get; set; }
}
