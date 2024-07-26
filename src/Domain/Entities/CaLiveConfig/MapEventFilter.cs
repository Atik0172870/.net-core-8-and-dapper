using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MapEventFilter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long MapEventFilterID { get; set; }

    [Required]
    public Guid MapUID { get; set; }

    [Required]
    public int EventCode { get; set; }

    [Required]
    public bool IsEnable { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
