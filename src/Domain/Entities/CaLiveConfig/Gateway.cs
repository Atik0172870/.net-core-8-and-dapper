using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Gateway
{
    [Key]
    public Guid GatewayId { get; set; }

    [Required]
    [MaxLength(50)]
    public string UNCName { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    public string MACAddress { get; set; } =null!;

    [Required]
    [MaxLength(16)]
    public string IPAddress { get; set; } = null!;

    [MaxLength(50)]
    public string? Passwrd { get; set; }

    public short? RFChannel { get; set; }

    public int? RFGroup { get; set; }

    public short? SyncWordUpper { get; set; }

    public short? SyncWordLower { get; set; }

    public bool? UseDHCP { get; set; }

    [MaxLength(20)]
    public string? DHCPName { get; set; }

    [MaxLength(16)]
    public string? SubNetMask { get; set; }

    public int? WirelessMode { get; set; }

    public int? NetworkType { get; set; }

    public int? WifiChannelNo { get; set; }

    public int? SecurityType { get; set; }

    public int? Authentication { get; set; }

    public int? GatewayEncryption { get; set; }

    public int? KeyType { get; set; }

    [MaxLength(2000)]
    public string? Key1Value { get; set; }

    [MaxLength(20)]
    public string? SSIDName { get; set; }

    [MaxLength(16)]
    public string? GatewayIPAddress { get; set; }

    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? ZoneId { get; set; }
}
