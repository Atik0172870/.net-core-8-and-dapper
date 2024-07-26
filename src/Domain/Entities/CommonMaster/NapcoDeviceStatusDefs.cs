using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("napcoDeviceStatusDefs")]
public class NapcoDeviceStatusDefs
{
    [Key]
    public int DeviceStatus { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; } = string.Empty;
}
