namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ElevAgFloors
{
    public int PnlRef { get; set; }
    public int RdrRef { get; set; }
    public int AccGroup { get; set; }
    public int FloorNumber { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public DateTime? LastUpdated { get; set; }
    public int CompanyId { get; set; }
}
