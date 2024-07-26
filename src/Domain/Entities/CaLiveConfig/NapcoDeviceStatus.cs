using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoDeviceStatus
{
    [Key]
    public int DeviceType { get; set; }

    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int DeviceID { get; set; }

    [Required]
    public int DeviceStatus { get; set; }

    [Required]
    public DateTime LastUpdate { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
