namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GeoFence
{
    public int ProfileId { get; set; }

    public Guid FenceId { get; set; }

    public string? FenceName { get; set; }

    public float? Radius { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    public DateTime? LastUpdated { get; set; }

    public int? CompanyId { get; set; }
}
