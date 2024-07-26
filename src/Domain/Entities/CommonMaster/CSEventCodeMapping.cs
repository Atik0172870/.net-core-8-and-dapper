using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("CSEventCodeMapping")]
public class CSEventCodeMapping
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EventClassID { get; set; }

    [Required]
    [StringLength(3)]
    public string CSEventCode { get; set; } = null!;

    [StringLength(250)]
    public string? CSEventName { get; set; }

    [StringLength(250)]
    public string? EventDescription { get; set; }

    public int? PulseFormatCode { get; set; }

    [Required]
    public bool IsRestore { get; set; } = false;
}
