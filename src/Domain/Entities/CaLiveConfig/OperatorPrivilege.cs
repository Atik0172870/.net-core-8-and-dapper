using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class OperatorPrivilege
{
    [Key]
    public Guid OperatorID { get; set; }

    [Key]
    public int ScreenID { get; set; }

    [Key]
    public int ScreenObjectID { get; set; }

    [Required]
    public int SecurityLevel { get; set; }
}
