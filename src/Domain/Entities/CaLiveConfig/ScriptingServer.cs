using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ScriptingServer
{
    [Key]
    public int WorkstationID { get; set; }

    [Required]
    [MaxLength(255)]
    public string PollingUNCName { get; set; } = null!;

    public string LastWorkStation { get; set; } = null!;

    public Guid? LastOperator { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }
}
