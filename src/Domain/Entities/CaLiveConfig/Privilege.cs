using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Privilege
{
    [Key]
    public int PrivilegeID { get; set; }

    [Required]
    [StringLength(100)]
    public string PrivilegeName { get; set; } = null!;

    public int ScreenID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public Guid? LastOperator { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
