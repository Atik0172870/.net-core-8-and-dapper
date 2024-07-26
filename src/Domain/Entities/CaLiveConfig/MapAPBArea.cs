using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MapAPBArea
{
    [Key]
    public Guid MapAPBAreaUID { get; set; }

    [Required]
    public int APBAreasID { get; set; }

    [Required]
    public Guid MapUID { get; set; }

    [Required]
    [StringLength(1000)]
    public string DrawingCode { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }
}
