using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("Event")]
public class Event
{
    [Key]
    public Guid Seqno { get; set; } = Guid.NewGuid();

    public int? Priority { get; set; }

    public int? Cat { get; set; }

    public int? PnlNo { get; set; }

    public DateTime? EDate { get; set; }

    public int? DeviceNo { get; set; }

    public int? Status { get; set; }

    public int? Facno { get; set; }

    public long? Badge { get; set; }

    [MaxLength(64)]
    public string? Class { get; set; }

    [MaxLength(120)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string? Name { get; set; }

    public int? Arch { get; set; }

    public Guid? AckOpr { get; set; }

    public DateTime? AckTStamp { get; set; }

    public string? Actions { get; set; }

    public bool? RespReq { get; set; }

    public Guid? CaObjectID { get; set; }

    public long? Tag { get; set; }

    public bool HasPhoto { get; set; } = false;

    public bool? HasVideo { get; set; }

    public bool? Pending { get; set; }

    public int? UTCOffset { get; set; }

    public int? Sphere { get; set; }

    public int CompanyId { get; set; }

    public int SeqNoFromLock { get; set; } = 0;

    public int RecordCount { get; set; } = 0;
}
