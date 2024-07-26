using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MapPointsEventFilter
{
    [Key]
    public long MapPointsEventFilterID { get; set; }

    [Required]
    public Guid MapPointsUID { get; set; }

    [Required]
    public Guid MapUID { get; set; }

    [Required]
    public int EventCode { get; set; }

    [Required]
    public bool IsEnable { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
