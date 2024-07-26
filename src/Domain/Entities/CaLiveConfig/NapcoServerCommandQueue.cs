using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoServerCommandQueue
{
    [Key]
    public int CommandID { get; set; }

    [Required]
    public int WorkstationID { get; set; }

    [Required]
    public int AlarmPanelID { get; set; }

    [Required]
    public int CommandType { get; set; }

    public int? AreaNumber { get; set; }

    public int? ZoneNumber { get; set; }

    public int? UserNumber { get; set; }

    [Required]
    public DateTime CommandTimestamp { get; set; }

    public int? Facility { get; set; }

    public long? Badge { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
