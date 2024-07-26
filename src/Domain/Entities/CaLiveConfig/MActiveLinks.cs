using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MActiveLinks
{
    [Key]
    public int PnlRef { get; set; }

    [Key]
    public int ProgNo { get; set; }

    [MaxLength(50)]
    public string Description { get; set; } = null!;

    public int? Priority { get; set; }

    public int? Device { get; set; }

    public int? EventCode { get; set; }

    public int? Category { get; set; }

    public int? Schedule { get; set; }

    public bool? UnDO { get; set; }

    public int? UnDoProgNo { get; set; }

    public bool? RespReq { get; set; }

    public int? ManualPriv { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    public bool? Enabled { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public Guid PanelObjectID { get; set; }
}
