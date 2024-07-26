using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MapPoints
{
    [Key]
    public Guid MapPointsUID { get; set; }

    [Required]
    public Guid MapUID { get; set; }

    [Required]
    public int DeviceType { get; set; }

    [Required]
    public Guid DeviceObjectID { get; set; }

    [Required]
    public float PointX { get; set; }

    [Required]
    public float PointY { get; set; }

    public Guid? MapAPBAreaUID { get; set; }

    public int? DvrCameraID { get; set; }

    public Guid? DvrServerID { get; set; }

    public short? PanelType { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
