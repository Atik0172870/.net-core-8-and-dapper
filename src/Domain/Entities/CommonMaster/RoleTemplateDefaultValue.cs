using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("RoleTemplateDefaultValue")]
public class RoleTemplateDefaultValue
{
    [Key]
    [Column(Order = 0)]
    public int TemplateType { get; set; }

    [Key]
    [Column(Order = 1)]
    public int ScreenID { get; set; }

    [StringLength(100)]
    public string? PluginAssembly { get; set; }

    [Key]
    [Column(Order = 2)]
    public int ScreenObjectID { get; set; }

    public int SecurityLevel { get; set; }
}
