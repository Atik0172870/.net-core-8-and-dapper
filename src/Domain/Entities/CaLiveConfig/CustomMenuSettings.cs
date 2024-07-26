using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CustomMenuSettings
{
    [Key]
    public Guid caObjectID { get; set; }

    [Required]
    public string DisplayName { get; set; } = null!;

    [Required]
    public string ApplicationPath { get; set; }= null!;

    [Required]
    public Guid LastOperator { get; set; }

    public DateTime? LastUpdate { get; set; }
    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
