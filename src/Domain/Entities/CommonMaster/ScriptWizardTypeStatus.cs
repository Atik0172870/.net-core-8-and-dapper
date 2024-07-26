using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("scriptWizard_TypeStatus")]
public class ScriptWizardTypeStatus
{
    [Key]
    [Column("scriptTypeID")]
    public int ScriptTypeID { get; set; }

    [Key]
    [Column("scriptStatus")]
    public int ScriptStatus { get; set; }

    [Required]
    [Column("scriptStatusName")]
    [StringLength(50)]
    public string ScriptStatusName { get; set; } = null!;
}
