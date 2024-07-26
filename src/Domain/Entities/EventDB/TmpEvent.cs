using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("tmpEvent")]
public class TmpEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Seqno { get; set; }

    public int? Priority { get; set; }

    public int? Cat { get; set; }

    public int? PnlNo { get; set; }

    public DateTime? EDate { get; set; }

    public int? DeviceNo { get; set; }

    public int? Status { get; set; }

    public int? Facno { get; set; }

    public long? Badge { get; set; }

    [StringLength(64)]
    public string Class { get; set; } = null!;

    [StringLength(120)]
    public string Description { get; set; } = null!;

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int? Arch { get; set; }

    public Guid? AckOpr { get; set; }

    public DateTime? AckTStamp { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string Actions { get; set; } = null!;

    public bool? RespReq { get; set; }

    public Guid? CaObjectID { get; set; }

    public long? Tag { get; set; }

    [Required]
    public bool HasPhoto { get; set; }

    public int? HasVideo { get; set; }

    public bool? Pending { get; set; }

    public int? UTCOffset { get; set; }

    public int CompanyId { get; set; }
}
