using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelRelays
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int RelayNumber { get; set; }

    [Required]
    public bool RelayConfigured { get; set; }

    [MaxLength(50)]
    public string? RelayName { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? MapId { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
