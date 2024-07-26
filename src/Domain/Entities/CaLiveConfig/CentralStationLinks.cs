using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CentralStationLinks
{
    [Key]
    public int cat { get; set; }

    [Key]
    public int pnlNo { get; set; }

    [Key]
    public int Number { get; set; }

    [Key]
    public int status { get; set; }

    public int? workstationId { get; set; }

    public int facility { get; set; }

    public long badge { get; set; }

    public Guid centralStationId { get; set; }

    public int codeToReport { get; set; }

    public bool shouldReport { get; set; }

    public int areaNum { get; set; }

    public int zoneNum { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime LastUpdated { get; set; }

    public int? UTCOffset { get; set; }

    public int? EventClassId { get; set; }

    public int? DeviceType { get; set; }
}
