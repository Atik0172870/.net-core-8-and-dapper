using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelAreaEventDef
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int AreaNumber { get; set; }

    [Key]
    [MaxLength(2)]
    public string StatusCode { get; set; } = null!;

    [Required]
    public bool GenerateEvent { get; set; }

    [Required]
    public int EventPriority { get; set; }

    [Required]
    public bool ResponseRequired { get; set; }

    [Required]
    public int RelayControlAction { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
