using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("ScreenObjects")]
public class ScreenObjects
{
    [Key]
    [Column(Order = 0)]
    public int ScreenObjectID { get; set; }

    [Key]
    [Column(Order = 1)]
    public int ScreenID { get; set; }

    [Required]
    [StringLength(150)]
    public string ObjectName { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string ObjectLabel { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string ObjectType { get; set; } = null!;

    [StringLength(100)]
    public string? LangObjectName { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }
}
