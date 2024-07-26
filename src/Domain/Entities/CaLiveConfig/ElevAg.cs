namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ElevAg
{
    public int PnlRef { get; set; }
    public int RdrRef { get; set; }
    public int AccGroup { get; set; }
    public int RelayNumber { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
}
