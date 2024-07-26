using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class PanelHoliday
{
    [Key]
    public int LocalCalendarNo { get; set; }

    [Key]
    public int PanelCalendarNo { get; set; }

    [Key]
    public int PanelNo { get; set; }

    public Guid? caObjectId { get; set; }

    public DateTime? LastUpdated { get; set; }

    [MaxLength(50)]
    public string? LastWorkstation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
