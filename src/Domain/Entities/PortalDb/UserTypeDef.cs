using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("UserTypeDef")]
public class UserTypeDef
{
    [Key]
    public int Id { get; set; }

    public string? UserType { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }
}
