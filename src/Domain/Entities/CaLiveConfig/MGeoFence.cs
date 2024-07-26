using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MGeoFence
{
    [Key]
    public int ProfileId { get; set; }

    [Required]
    [StringLength(50)]
    public string ProfileName { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
