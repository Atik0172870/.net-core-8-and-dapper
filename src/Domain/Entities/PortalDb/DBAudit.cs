using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("DBAudit")]
public class DBAudit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long AuditId { get; set; }

    public DateTime? RevisionStamp { get; set; }

    [StringLength(50)]
    public string? TableName { get; set; }

    [StringLength(50)]
    public string? OperatorName { get; set; }

    [StringLength(50)]
    public string? StationName { get; set; }

    [StringLength(1)]
    public string? Actions { get; set; }

    [StringLength(200)]
    public string? Description { get; set; }

    public XElement? OldData { get; set; }

    public XElement? NewData { get; set; }

    [StringLength(1000)]
    public string? ChangedColumns { get; set; }

    [StringLength(50)]
    public string? LastOperator { get; set; }

    public int? UTCOffset { get; set; }

    public int? ParentAuditId { get; set; }
}
