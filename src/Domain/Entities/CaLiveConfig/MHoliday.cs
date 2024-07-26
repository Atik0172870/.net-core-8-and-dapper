using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MHoliday
{
    [Key]
    public int CalendarNo { get; set; }

    [Required]
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
