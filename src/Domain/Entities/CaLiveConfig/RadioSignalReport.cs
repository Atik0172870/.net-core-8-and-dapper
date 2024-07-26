using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RadioSignalReport
{
    [Required]
    [StringLength(20)]
    public string ICCID { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public int? SignalStrengthValue { get; set; }

    public int? Blink { get; set; }

    public int? Roaming { get; set; }

    public int? Quality { get; set; }
}
