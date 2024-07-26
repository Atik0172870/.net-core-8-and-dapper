using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoMPermissions
{
    [Key]
    public int PermissionID { get; set; }

    [Required]
    [MaxLength(50)]
    public string PermissionName { get; set; } = null !;

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public string LastWorkStation { get; set; }=null!;

    public Guid? LastOperator { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
