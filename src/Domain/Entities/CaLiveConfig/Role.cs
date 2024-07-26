using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Role
{
    [Required]
    public Guid RoleID { get; set; }

    [Required]
    [MaxLength(200)]
    public string RoleName { get; set; } = null!;

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public Guid caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public bool? IsPortalRole { get; set; }
}
