namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DBAudit
{
    public int AuditId { get; set; }
    public DateTime? RevisionStamp { get; set; }
    public string? TableName { get; set; }
    public string? OperatorName { get; set; }
    public string? StationName { get; set; }
    public string? Actions { get; set; }
    public string? Description { get; set; }
    public string? OldData { get; set; }
    public string? NewData { get; set; }
    public string? ChangedColumns { get; set; }
    public Guid? LastOperator { get; set; }
    public Guid? caObjectID { get; set; }
    public int? UTCOffset { get; set; }
    public int? ParentAuditId { get; set; }
    public int? CompanyId { get; set; }
}
