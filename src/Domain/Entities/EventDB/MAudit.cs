using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("MAudit")]
public class MAudit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditId { get; set; }

    public DateTime? RevisionStamp { get; set; }

    [StringLength(32)]
    public string ObjectName { get; set; } = null!;

    [StringLength(32)]
    public string OperatorName { get; set; } = null!;

    [StringLength(32)]
    public string StationName { get; set; } = null!;
}
