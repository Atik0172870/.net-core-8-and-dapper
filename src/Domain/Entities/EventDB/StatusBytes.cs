using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("StatusBytes")]
public class StatusBytes
{
    [Key]
    public int Panel { get; set; }

    [Key]
    public int Type { get; set; }

    [Key]
    public int CompanyId { get; set; }

    [StringLength(500)]
    public string CommaSeparatedByteString { get; set; } = null!;

    public DateTime? LastUpdated { get; set; }
}
