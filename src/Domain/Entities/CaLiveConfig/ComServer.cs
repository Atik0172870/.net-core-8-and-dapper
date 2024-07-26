using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ComServer
{
    [Key]
    public int ComID { get; set; }

    [Required]
    public int WorkstationID { get; set; }

    public int? Record { get; set; }
    public int? Val1 { get; set; }
    public long? Val2 { get; set; }
    public int? Val3 { get; set; }
    public int? Val4 { get; set; }
    public int? Val5 { get; set; }
    public byte[]? pkt { get; set; }
    public DateTime? LastUpdated { get; set; }
    public Guid? LastOperator { get; set; }
    public string? LastWorkStation { get; set; }
    public int? UTCExecTime { get; set; }
}
