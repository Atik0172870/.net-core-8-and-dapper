using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("napcoDeviceStatus")]
public class NapcoDeviceStatus
{
    [Key]
    [Column(Order = 1)]
    public int DeviceType { get; set; }

    [Key]
    [Column(Order = 2)]
    public int AlarmPanelID { get; set; }

    [Key]
    [Column(Order = 3)]
    public int DeviceID { get; set; }

    [Required]
    public int DeviceStatus { get; set; }

    [Required]
    public DateTime LastUpdate { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }
}
