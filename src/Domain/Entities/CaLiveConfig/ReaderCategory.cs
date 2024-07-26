using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ReaderCategory
{
    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int RdrNo { get; set; }

    [Required]
    public int CatNumber { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [StringLength(50)]
    public string? LastWorkstation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
