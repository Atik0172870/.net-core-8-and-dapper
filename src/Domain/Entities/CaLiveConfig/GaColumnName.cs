using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaColumnName
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(254)]
    public string Column_Name { get; set; } = null!;
}
