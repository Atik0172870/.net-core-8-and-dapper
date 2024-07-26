using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("coreObjectDefs")]
public class CoreObjectDef
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ObjectType { get; set; }

    [Required]
    [StringLength(50)]
    public string ObjectTypeName { get; set; } = null!;

    [StringLength(255)]
    public string? EditorFullClassName { get; set; }

    [StringLength(255)]
    public string? QuickFullClassName { get; set; }

    [Required]
    public int ParentObjectType { get; set; }

    [StringLength(255)]
    public string? TreeResultsQuery { get; set; }

    [StringLength(255)]
    public string? ParentTreeResultsQuery { get; set; }

    [Required]
    public bool ShowAddNewMenu { get; set; } = true;

    [Required]
    public bool AllowChildrenIfNew { get; set; } = false;

    [Required]
    public bool ShowChildPlaceholders { get; set; } = false;

    [Required]
    public bool ShowShowUsageMenu { get; set; } = false;

    [Required]
    public bool ShowShowEventMenu { get; set; } = false;

    public bool? ShowAsDialog { get; set; } = false;
}
