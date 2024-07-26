using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ActiveThreatLevel
{
    [Key]
    public int LockdownID { get; set; }

    [Key]
    public int CatNumber { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
