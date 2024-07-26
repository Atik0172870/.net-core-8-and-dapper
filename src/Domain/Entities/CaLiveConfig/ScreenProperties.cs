using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ScreenProperties
{
    [Required]
    public Guid OperatorId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Screen { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string xml { get; set; } = null!;
}
