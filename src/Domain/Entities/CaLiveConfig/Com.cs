using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Com
{
    [Key]
    public int ComId { get; set; }

    public int HCSNo { get; set; }

    public int ComPort { get; set; }

    public int? Baud { get; set; }

    public int? Type { get; set; }

    public int? Pwd { get; set; }

    public string? Passwrd { get; set; }

    public string? IPAddress { get; set; }

    public int? IPPort { get; set; }

    public bool? BinaryMode { get; set; }

    public bool? NoPolling { get; set; }

    public int? ZoneId { get; set; }

    public string? MACAddress { get; set; }

    public short? RFChannel { get; set; }

    public int? RFGroup { get; set; }

    public short? SyncWordUpper { get; set; }

    public short? SyncWordLower { get; set; }

    public bool? UseDHCP { get; set; }

    public string? DHCPName { get; set; }

    public string? SubNetMask { get; set; }

    public int? WirelessMode { get; set; }

    public int? NetworkType { get; set; }

    public int? WifiChannelNo { get; set; }

    public int? SecurityType { get; set; }

    public int? Authentication { get; set; }

    public int? GatewayEncryption { get; set; }

    public int? KeyType { get; set; }

    public string? Key1Value { get; set; }

    public string? SSIDName { get; set; }

    public string? GatewayIPAddress { get; set; }

    public int? RepeaterCount { get; set; }

    public string? HostIPAddress { get; set; }

    public int? GatewayPort { get; set; }

    public DateTime LastUpdated { get; set; }

    [Key]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    public int CompanyId { get; set; }

    public string? NLMFirmwareVersion { get; set; }

    public string? NLMBootloaderVersion { get; set; }

    public int? NLMServerPort { get; set; }

    public int NLMIsDHCP { get; set; }

    public string? NLMDeviceIpAddress { get; set; }

    public string? NLMSubnetMask { get; set; }

    public string? NLMGateway { get; set; }

    public int NLMAesEncryptingType { get; set; }

    public string? NLMCredUserName { get; set; }

    public string? NLMCredUserPassword { get; set; }

    public string? NLMCloudIpAddress { get; set; }

    public int NLMCloudRemotePort { get; set; }

    public string? NLMCloudURLAddress { get; set; }

    public int? CheckinInterval { get; set; }

    public int? SocketTimeoutInSec { get; set; }

    public int OperationalMode { get; set; }

    public int? ConnectionTimeout { get; set; }

    public int? EnabledFeatures { get; set; }

    public bool? Enabled { get; set; }

    public string? WifiSSID { get; set; }

    public string? WifiPassword { get; set; }

    public bool? SendEventWithCheckIn { get; set; }

    public string? DeviceID { get; set; }

    public int ComPortAddress { get; set; }

    public int ComportAddrType { get; set; }

    public int SubAddress { get; set; }

    public int SubAddressType { get; set; }

    public string? Description { get; set; }

    public string? DeviceSN { get; set; }

    public bool? AutoEnrolFlag { get; set; }
}
