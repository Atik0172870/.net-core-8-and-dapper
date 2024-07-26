using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoWorkstation
{
    public int WorkstationID { get; set; }

    [Required]
    public string PollingUNCName { get; set; } = null!;

    [Required]
    public string PollingIPAddress { get; set; } = null!;

    public string? LastWorkStation { get; set; }

    public Guid? LastOperator { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }
}
