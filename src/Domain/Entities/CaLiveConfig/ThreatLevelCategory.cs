using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ThreatLevelCategory
{
    [Key]
    public int CatNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectId { get; set; }

    [Required]
    public Guid LastOperator { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastWorkstation { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }
}
