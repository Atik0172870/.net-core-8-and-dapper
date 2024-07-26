using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("UserStateDef")]
public class UserStateDef
{
    [Key]
    public int Id { get; set; }

    public string? State { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }
}
