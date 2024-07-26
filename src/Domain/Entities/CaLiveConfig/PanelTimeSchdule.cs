using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class PanelTimeSchdule
{
    [Key]
    public int LocalTzNo { get; set; }

    [Key]
    public int PanelTzNo { get; set; }

    [Key]
    public int PanelNo { get; set; }

    public Guid? caObjectId { get; set; }

    public DateTime? LastUpdated { get; set; }

    [MaxLength(100)]
    public string? LastWorkstation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
