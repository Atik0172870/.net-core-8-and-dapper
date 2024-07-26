using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;
[Table("Format")]
public class Format
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int FmtNo { get; set; } = 1;

    [Required]
    [StringLength(50)]
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

    public DateTime LastUpdated { get; set; } = DateTime.Now;

    public Guid caObjectID { get; set; } = Guid.NewGuid();

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }
}
