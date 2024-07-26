using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MLockdownAreas
{
    [Key]
    public int AreaNo { get; set; }

    [StringLength(50)]
    public string? AreaName { get; set; }

    public bool? Active { get; set; }

    public bool? ActiveByOper { get; set; }

    public int? Categories { get; set; }

    public bool? DenyCategory { get; set; }

    public Guid? caObjectID { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
