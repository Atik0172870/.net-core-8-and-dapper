using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ReaderGeoProfile
{
    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int RdrNo { get; set; }

    [Required]
    public int ProfileNo { get; set; }

    [Required]
    public Guid FenceNo { get; set; }

    [StringLength(10)]
    public string? ScheduleNo { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
