using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CompanyInfo
{
    [Key]
    public int CompanyID { get; set; }

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public int HostCompanyId { get; set; }
}
