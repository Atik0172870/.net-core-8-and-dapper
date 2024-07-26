using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class SchedEvent
{
    [Required]
    public DateTime StartDate { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SchId { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Device { get; set; }

    public int? PnlNo { get; set; }

    public int? DeviceNo { get; set; }

    public int? GroupNo { get; set; }

    public int? Schedule { get; set; }

    public int? FieldNo { get; set; }

    [MaxLength(50)]
    public string Description { get; set; } = null!;

    [MaxLength(50)]
    public string GroupName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public long? BadgeFrom { get; set; }

    public long? BadgeTo { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string FieldIn { get; set; } = null!;

    [MaxLength(40)]
    public string ValueIn { get; set; } = null!;

    [MaxLength(20)]
    public string FieldOut { get; set; } = null!;

    [MaxLength(40)]
    public string ValueOut { get; set; } = null!;

    public int? Status { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public Guid caObjectId { get; set; }

    public DateTime? LastUpdated { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
