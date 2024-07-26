using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaAlias
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(254)]
    public string Table_Name { get; set; } = null!;

    [StringLength(254)]
    public string? Field_Name { get; set; }

    [StringLength(254)]
    public string? Alias_Name { get; set; }

    public int? Visible { get; set; }
}
