using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("MRoleTemplate")]
public class MRoleTemplate
{
    [Key]
    public Guid RoleTemplateID { get; set; }

    [Required]
    [StringLength(50)]
    public string RoleTemplateName { get; set; } = string.Empty;

    [Required]
    public int CloudUserType { get; set; } = 0;

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now;

    [StringLength(50)]
    public string? LastWorkstation { get; set; }

    [StringLength(50)]
    public string? LastOperator { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public bool IsDefault { get; set; } = true;
}
