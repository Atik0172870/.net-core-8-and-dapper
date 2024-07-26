using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class FacilityMap
{
    [Key]
    public int MapId { get; set; }

    [Required]
    [MaxLength(50)]
    public string MapName { get; set; } = null!;

    [MaxLength(64)]
    public string? MapDescription { get; set; }

    public byte[]? MapImage { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }
    public string? LastWorkStation { get; set; }
    public int CompanyId { get; set; }
}
