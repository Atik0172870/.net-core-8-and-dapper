using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelZoneEventDef
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    [MaxLength(2)]
    public string StatusCode { get; set; } = null!;

    [Key]
    public int ZoneNumber { get; set; }

    [Required]
    public bool GenerateEvent { get; set; }

    [Required]
    public int EventPriority { get; set; }

    [Required]
    public bool ResponseRequired { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
