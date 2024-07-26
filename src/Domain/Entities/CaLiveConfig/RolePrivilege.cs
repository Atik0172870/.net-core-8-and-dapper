using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RolePrivilege
{
    [Required]
    public Guid RoleID { get; set; }

    [Required]
    public int ScreenID { get; set; }

    [Required]
    public int ScreenObjectID { get; set; }

    [Required]
    public int SecurityLevel { get; set; }
}
