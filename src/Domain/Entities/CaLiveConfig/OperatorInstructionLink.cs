using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class OperatorInstructionLink
{
    [Key]
    [Column(Order = 0)]
    public int Cat { get; set; }

    [Key]
    [Column(Order = 1)]
    public int PnlNo { get; set; }

    [Key]
    [Column(Order = 2)]
    public int DeviceNo { get; set; }

    [Key]
    [Column(Order = 3)]
    public int Status { get; set; }

    [Required]
    public bool InstructionsEnabled { get; set; }

    public Guid? InstructionID { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    [Required]
    public Guid CaObjectId { get; set; }

    public bool? SoundEnabled { get; set; }

    public int? SoundInterval { get; set; }

    public int CompanyId { get; set; }

    public int? SoundIndex { get; set; }
}
