using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaLayoutField
{
    [Key]
    [Column("DBField")]
    public string DBField { get; set; } = null!;
}
