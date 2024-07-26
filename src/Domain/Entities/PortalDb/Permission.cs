using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("Permissions")]
public class Permission
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
