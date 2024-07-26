using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class LockStatus
{
    [Key]
    public int PnlRef { get; set; }

    [Key]
    public int Comport { get; set; }

    public int? RxRSSI { get; set; }

    public int? TxRSSI { get; set; }

    [MaxLength(50)]
    public string Version { get; set; } = null!;

    [MaxLength(50)]
    public string Assigned { get; set; } =null!;

    [MaxLength(50)]
    public string LockType { get; set; }=null!;

    [MaxLength(50)]
    public string LockId { get; set; }=null !;

    [MaxLength(50)]
    public string Status { get; set; } = null!;

    [MaxLength(50)]
    public string Battery { get; set; } = null!;

    public int? RepeaterAddress { get; set; }

    public DateTime? LastUpdated { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int ComPortAddress { get; set; }
}
