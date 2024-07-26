using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class AccGrp
{
    [Key]
    [Column(Order = 0)]
    public int PnlRef { get; set; }

    [Key]
    [Column(Order = 1)]
    public int Agno { get; set; }

    public int? Tz1 { get; set; }

    public int? Tz2 { get; set; }

    // Add other nullable int properties for Tz3 to Tz16

    public Guid caObjectID { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}


public class ManualPrivilege
{
    [Key]
    public Guid OperatorID { get; set; }

    [Key]
    public int ManualPrivilegeColumn { get; set; } 

    [Key]
    public int CompanyId { get; set; }
}
