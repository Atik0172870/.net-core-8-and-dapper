using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class OperatorInstruction
{
    [Key]
    public Guid InstructionID { get; set; }

    [Required]
    [StringLength(50)]
    public string InstructionName { get; set; } = null!;

    public string? InstructionMsg { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    public Guid? CaObjectId { get; set; }

    public int CompanyId { get; set; }
}
