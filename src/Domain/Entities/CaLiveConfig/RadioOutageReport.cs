using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RadioOutageReport
{
    [Required]
    [StringLength(20)]
    public string ICCID { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public int? ActiveIndex { get; set; }

    public int? EventType { get; set; }

    public int? CurrentIndex { get; set; }
}
