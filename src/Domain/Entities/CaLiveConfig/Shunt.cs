using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Shunt
{
    [Key]
    public int ShuntId { get; set; }

    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int InpRef { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    public string LastWorkStation { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }
}
