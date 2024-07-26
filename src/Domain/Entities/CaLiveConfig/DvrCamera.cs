namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DvrCamera
{
    public int DvrCameraID { get; set; }
    public Guid DvrServerID { get; set; }
    public string CameraName { get; set; } = null!;
    public DateTime? LastUpdated { get; set; }
    public bool? EnableNotification { get; set; }
    public int? Tzno { get; set; }
    public int? Priority { get; set; }
    public int? MapId { get; set; }
    public string VendorCameraID { get; set; } = null!;
    public Guid caObjectID { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
}
