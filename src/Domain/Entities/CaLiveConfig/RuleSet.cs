using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RuleSet
{
    [Required]
    [MaxLength(128)]
    public string RuleSetName { get; set; } = null!;

    [Required]
    public int MajorVersion { get; set; }

    [Required]
    public int MinorVersion { get; set; }

    [Column(TypeName = "ntext")]
    public string RuleSetContent { get; set; } = null!;

    [MaxLength(256)]
    public string AssemblyPath { get; set; } = null!;

    [MaxLength(128)]
    public string ActivityName { get; set; } = null!;

    [Required]
    public DateTime ModifiedDate { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
