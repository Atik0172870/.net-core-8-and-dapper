using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CategoryCounters
{
    [Key]
    [Column(Order = 0)]
    public int PnlNo { get; set; }

    [Key]
    [Column(Order = 1)]
    public int CatNo { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    public int? LowWater { get; set; }

    public int? HiWater { get; set; }

    public bool? EventMsg { get; set; }

    public int? Priority { get; set; }

    public bool? RespReq { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
