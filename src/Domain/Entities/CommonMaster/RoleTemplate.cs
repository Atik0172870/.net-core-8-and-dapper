using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("RoleTemplate")]
public class RoleTemplate
{
    [Key]
    [Column("RoleTemplateID")]
    public Guid RoleTemplateID { get; set; }

    [Column("ScreenID")]
    public int ScreenID { get; set; }

    [Column("PluginAssembly")]
    [StringLength(100)]
    public string PluginAssembly { get; set; } = null!;

    [Column("ScreenObjectID")]
    public int ScreenObjectID { get; set; }

    [Column("SecurityLevel")]
    public int SecurityLevel { get; set; }

    [ForeignKey("RoleTemplateID")]
    public virtual MRoleTemplate MRoleTemplate { get; set; } = null!;
}
