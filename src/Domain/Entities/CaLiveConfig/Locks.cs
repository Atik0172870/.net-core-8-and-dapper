using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Locks
{
    [Key]
    public Guid LockID { get; set; }

    [Required]
    [MaxLength(50)]
    public string LockAddress { get; set; } = null!;

    public int? LockType { get; set; }

    [Required]
    public Guid GatewayID { get; set; }

    public bool? Enabled { get; set; }

    public bool? DegradeMode { get; set; }

    public int? DefaultCalendar { get; set; }

    public int? LockTransactionSchedule { get; set; }

    public int? LockUpdateSchedule { get; set; }

    public int? LockAssigned { get; set; }

    public bool? LockChanged { get; set; }

    public int? ZoneId { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkstation { get; set; } = null!;
}
