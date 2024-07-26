using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelArea
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int AreaNumber { get; set; }

    [Required]
    public bool AreaConfigured { get; set; }

    [MaxLength(50)]
    public string? AreaName { get; set; }

    [Required]
    public int AlarmAreaType { get; set; }

    [Required]
    public int ManualPriv { get; set; }

    [Required]
    public bool UseRelayControl { get; set; }

    [Required]
    public bool IsAccessControlPanel { get; set; }

    public int? RelayControlPanel { get; set; }

    public int? RelayControlRelay { get; set; }

    [Required]
    public Guid CaObjectID { get; set; } = Guid.NewGuid();

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? MapId { get; set; }

    [Key]
    [Required]
    public int CompanyId { get; set; }
}
