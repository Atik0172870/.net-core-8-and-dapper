using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("napcoAlarmPanelDef")]
public class NapcoAlarmPanelDef
{
    [Key]
    public int PanelType { get; set; }

    [Required]
    [StringLength(50)]
    public string PanelTypeName { get; set; } = string.Empty;

    public int? MaxAreas { get; set; } = 8;

    public int? MaxZones { get; set; } = 255;

    public int? MaxUsers { get; set; } = 255;

    public int? MaxRelays { get; set; }
}
