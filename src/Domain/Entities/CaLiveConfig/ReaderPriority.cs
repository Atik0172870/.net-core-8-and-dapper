using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ReaderPriority
{
    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int RdrNo { get; set; }

    public int? FDPrior { get; set; }

    public int? OTLPrior { get; set; }

    public int? DuPrior { get; set; }

    public int? TrkPrior { get; set; }

    public int? VPrior { get; set; }

    public int? APBPrior { get; set; }

    public int? OTHPrior { get; set; }

    public int? ManPrior { get; set; }

    public int? BypPrior { get; set; }

    public int? FreePrior { get; set; }

    public int? PINPrior { get; set; }

    public int? ValidPrior { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public Guid caObjectId { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
