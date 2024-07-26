namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ElevFloors
{
    public int FloorNumber { get; set; }
    public string FloorName { get; set; } = null!;
    public DateTime LastUpdated { get; set; }
    public Guid caObjectID { get; set; }
    public int ElevFacilityId { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int? UTCOffset { get; set; }
    public int CompanyId { get; set; }
}
