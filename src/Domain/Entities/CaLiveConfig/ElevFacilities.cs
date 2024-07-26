namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ElevFacilities
{
    public int ElevFacilityId { get; set; }
    public string ElevFacilityName { get; set; } = null!;
    public DateTime LastUpdated { get; set; }
    public Guid caObjectID { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int? UTCOffset { get; set; }
    public int CompanyId { get; set; }
}
