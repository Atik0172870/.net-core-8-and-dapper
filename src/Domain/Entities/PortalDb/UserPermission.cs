using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("UserPermissions")]
public class UserPermission
{
    [Key]
    [Column(Order = 0)]
    public long UserId { get; set; }

    [Key]
    [Column(Order = 1)]
    public int PermissionId { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public int? UTCOffset { get; set; }

    [StringLength(50)]
    public string? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }
}

