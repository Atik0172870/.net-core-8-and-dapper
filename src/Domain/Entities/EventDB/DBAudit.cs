using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("DBAudit")]
public class DBAudit
{
    [Key]
    public int AuditId { get; set; }

    public DateTime? RevisionStamp { get; set; }

    [MaxLength(50)]
    public string? TableName { get; set; }

    [MaxLength(50)]
    public string? OperatorName { get; set; }

    [MaxLength(50)]
    public string? StationName { get; set; }

    [MaxLength(1)]
    public string? Actions { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    public string? OldData { get; set; }

    public string? NewData { get; set; }

    [MaxLength(1000)]
    public string? ChangedColumns { get; set; }

    public Guid? LastOperator { get; set; }

    public Guid? CaObjectID { get; set; }

    public int? UTCOffset { get; set; }

    public int? ParentAuditId { get; set; }

    public int? CompanyId { get; set; }
}
