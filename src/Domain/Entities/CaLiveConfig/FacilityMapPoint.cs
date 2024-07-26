using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class FacilityMapPoint
{
    [Key]
    public int MapPointId { get; set; }

    [Required]
    public int MapId { get; set; }

    [Required]
    public int Type { get; set; }

    [Required]
    public int PanelNo { get; set; }

    [Required]
    public int DevNo { get; set; }

    [Required]
    public float PtX { get; set; }

    [Required]
    public float PtY { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
