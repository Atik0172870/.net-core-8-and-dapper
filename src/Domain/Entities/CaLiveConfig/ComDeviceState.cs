using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ComDeviceState
{
    [Key]
    public int CompanyId { get; set; }

    [Key]
    public int ComPort { get; set; }

    public int? ComType { get; set; }

    [Key]
    public int ComPortAddress { get; set; }

    public int? ComPortAddrType { get; set; }

    public string? DeviceId { get; set; }

    public string? ChildDeviceId { get; set; }

    public int? DeviceState { get; set; }
}
