using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CentralStationAutho
{
    [Key]
    [Column(Order = 0)]
    public string centralStationId { get; set; } = null!;

    [Key]
    [Column(Order = 1)]
    public int workstationId { get; set; }

    [StringLength(8)]
    public string? NextAutho { get; set; }

    public short? NoClone0 { get; set; }

    public short? NoClone1 { get; set; }

    public int? AcctLink { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
