using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Format
{
    [Key]
    public int FmtNo { get; set; }

    [Required]
    public string Description { get; set; } = null!;

    public int? FmtLength { get; set; }

    public int? FmtType { get; set; }

    public int? FmtSS { get; set; }

    public int? FmtSSO { get; set; }

    public int? FmtCSOff { get; set; }

    public int? FmtCSLen { get; set; }

    public int? FmtDOff { get; set; }

    public int? FmtDLen { get; set; }

    public int? FmtES { get; set; }

    public int? FmtESO { get; set; }

    public int? FmtFS { get; set; }

    public int? FmtFSO { get; set; }

    public int? FmtCLen { get; set; }

    public int? FmtCOff { get; set; }

    public int? FmtILen { get; set; }

    public int? FmtIOff { get; set; }

    public int? FmtOCOff { get; set; }

    public int? FmtOCLen { get; set; }

    public int? FmtOIOff { get; set; }

    public int? FmtOILen { get; set; }

    public int? FmtPIOff { get; set; }

    public int? FmtPILen { get; set; }

    public int? FmtPOAOff { get; set; }

    public int? FmtPOALen { get; set; }

    public int? FmtFLen { get; set; }

    public int? FmtFOff { get; set; }

    public bool? PivStatus { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
