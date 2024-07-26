using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Timezone
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TzId { get; set; }

    public int? TzNo { get; set; }
    public int? DayFrom { get; set; }
    public int? DayTo { get; set; }
    public int? FrHr { get; set; }
    public int? FrMin { get; set; }
    public int? ToHr { get; set; }
    public int? ToMin { get; set; }
    public DateTime? TimeFrom { get; set; }
    public DateTime? TimeTo { get; set; }
    public DateTime LastUpdated { get; set; }
    public Guid? LastOperator { get; set; }
    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;
    public Guid caObjectId { get; set; }
    public int? UTCOffset { get; set; }
    public int CompanyId { get; set; }
}
