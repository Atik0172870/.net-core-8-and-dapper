using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MAccGrp
{
    [Key]
    public int AgrpNo { get; set; }

    [MaxLength(50)]
    public string Description { get; set; } = null!;

    public bool? PointAccess { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
