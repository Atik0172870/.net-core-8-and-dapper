using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("napcoConnectionTypes")]
public class NapcoConnectionTypes
{
    [Key]
    public int ConnectionType { get; set; }

    [Required]
    [StringLength(50)]
    public string ConnectionTypeName { get; set; } = string.Empty;
}
