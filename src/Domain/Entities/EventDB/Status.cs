using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("Status")]
public class Status
{
    [Key]
    public int Panel { get; set; }

    [Key]
    public int Type { get; set; }

    [Key]
    public int Device { get; set; }

    public int? HCSNo { get; set; }

    public int? StatusValue { get; set; }

    public DateTime? SDate { get; set; }

    public int? State { get; set; }

    [StringLength(20)]
    public string Version { get; set; } = null!;

    public int? MaxCards { get; set; }

    public int? UsedCards { get; set; }

    public int? ExpMem { get; set; }

    public int? MaxXact { get; set; }

    public int? Xact { get; set; }

    public int? MaxAG { get; set; }

    public int? UsedAG { get; set; }

    public int? MaxAlp { get; set; }

    [StringLength(100)]
    public string ExpIo { get; set; } = null!;

    public Guid? CaObjectId { get; set; }

    public int CompanyId { get; set; }

    public bool IsCheckinFailureReported { get; set; }
}
