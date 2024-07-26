using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MTimezon
{
    [Key]
    public int TzNum { get; set; }

    [StringLength(41)]
    public string? Description { get; set; }

    public int? GroupNo { get; set; }

    public int? HolGroups { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
