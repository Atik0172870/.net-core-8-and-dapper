namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ElevServers
{
    public int ServerId { get; set; }
    public int ServerType { get; set; }
    public string ServerIP { get; set; } = null!;
    public int? ServerPort { get; set; }
    public string ServerName { get; set; } = null!;
    public string? WorkstationName { get; set; }
    public string? ServerParam { get; set; }
    public int ElevFacilityId { get; set; }
    public DateTime LastUpdated { get; set; }
    public Guid caObjectID { get; set; }
    public Guid? LastOperator { get; set; }
    public string? LastWorkStation { get; set; }
    public int? UTCOffset { get; set; }
    public int CompanyId { get; set; }
}
