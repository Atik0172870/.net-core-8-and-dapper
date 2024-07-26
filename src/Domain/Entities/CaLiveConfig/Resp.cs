using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Resp
{
    [Required]
    [StringLength(65)]
    public string Description { get; set; } = null!;

    public Guid? caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }
}
