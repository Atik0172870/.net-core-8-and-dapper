using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelRelayEventDef
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int RelayNumber { get; set; }

    [Key]
    [MaxLength(2)]
    public string StatusCode { get; set; } = null!;

    [Required]
    public bool GenerateEvent { get; set; }

    [Required]
    public int EventPriority { get; set; }

    [Required]
    public bool ResponseRequired { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
