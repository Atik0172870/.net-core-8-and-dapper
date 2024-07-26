using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class LockdownAreas
{
    [Key]
    public int AreaNo { get; set; }

    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int RdrNo { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }
}
