using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelUsers
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int UserNumber { get; set; }

    [Required]
    public bool UserConfigured { get; set; }

    [MaxLength(255)]
    public string? Username { get; set; }

    [Required]
    public bool LinkToBadge { get; set; }

    public int? Facility { get; set; }

    public long? Badge { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
