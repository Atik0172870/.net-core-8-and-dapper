using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MShunt
{
    [Key]
    public int ShuntId { get; set; }

    [Required]
    [StringLength(100)]
    public string ShuntName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool? Active { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
