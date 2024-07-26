using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MActiveThreatLevel
{
    [Key]
    public int LockdownID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Description { get; set; } = null!;

    [Required]
    public int LockdownColor { get; set; }

    [Required]
    public bool Active { get; set; }

    public int? LockoutArea { get; set; }

    public bool? DenyAccess { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    [Required]
    public Guid LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkstation { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }
}
