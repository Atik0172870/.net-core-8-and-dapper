using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MPrivilege
{
    [Key]
    public int PrivilegeID { get; set; }

    [Required]
    [StringLength(50)]
    public string PrivilegeName { get; set; } = string.Empty;

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
