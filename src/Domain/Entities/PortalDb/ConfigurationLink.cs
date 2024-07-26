using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;
[Table("ConfigurationLink")]
public class ConfigurationLink
{
    [Key, Column(Order = 0)]
    [StringLength(20)]
    public string MACAddress { get; set; } = null!;

    [Key, Column(Order = 1)]
    public long CustomerId { get; set; }

    [StringLength(20)]
    public string? DeviceID { get; set; }

    [Key, Column(Order = 2)]
    public int ComPortAddress { get; set; }

    public int SubAddress { get; set; }

    public int SubAddressType { get; set; }
}
