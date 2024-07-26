using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("scriptWizard_Types")]
public class ScriptWizardType
{
    [Key]
    public int ScriptTypeID { get; set; }

    [Required]
    [StringLength(50)]
    public string ScriptTypeName { get; set; } = null!;
}
