using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class BadgeUpdate
{
    [Key]
    [Column(Order = 0)]
    public Guid PersonID { get; set; }

    [Key]
    [Column(Order = 1)]
    public long Badge { get; set; }

    [Key]
    [Column(Order = 2)]
    public int Facility { get; set; }

    [Required]
    public int LVPnl { get; set; }

    [Required]
    public int LVRdr { get; set; }

    [Required]
    public DateTime LVDate { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public bool? Enabled { get; set; }

    public int? APBSet { get; set; }

    public int? APBArea { get; set; }

    public int? UseCount { get; set; }
}
