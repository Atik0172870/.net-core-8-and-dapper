using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class LocationInfo
{
    [Key]
    public int LocationID { get; set; }

    [Required]
    [MaxLength(500)]
    public string Location { get; set; } = null!;

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
