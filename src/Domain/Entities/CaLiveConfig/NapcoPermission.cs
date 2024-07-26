using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPermission
{
    [Key]
    public int PermissionID { get; set; }

    [Required]
    public int AlarmPanelID { get; set; }

    [Required]
    public int AreaNumber { get; set; }

    [Required]
    public bool CanArm { get; set; }

    [Required]
    public bool CanDisarm { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
