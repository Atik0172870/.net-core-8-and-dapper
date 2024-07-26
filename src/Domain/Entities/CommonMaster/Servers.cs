using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("Servers")]
public class Servers
{
    [Key]
    public Guid ID { get; set; }

    [Key]
    public int NetStationId { get; set; }

    [Key]
    public int Device { get; set; }

    [StringLength(32)]
    public string? UNCName { get; set; }

    public bool? LoggedOn { get; set; }

    [StringLength(32)]
    public string? Operator { get; set; }

    public DateTime? LoggedOnTime { get; set; }

    public DateTime? LastUpdated { get; set; }
}
