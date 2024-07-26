using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("Station")]
public class Station
{
    [Key]
    public int NetStationId { get; set; }

    [Key]
    public int Device { get; set; }

    [StringLength(32)]
    public string UNCName { get; set; } = null!;

    public bool? LoggedOn { get; set; }

    [StringLength(32)]
    public string Operator { get; set; } = null!;

    public DateTime? LoggedOnTime { get; set; } = null!;

    public DateTime? LastUpdated { get; set; }

    public int CompanyId { get; set; }
}
