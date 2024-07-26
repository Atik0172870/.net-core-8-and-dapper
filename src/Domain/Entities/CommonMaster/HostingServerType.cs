using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("HostingServerType")]
public class HostingServerType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(200)]
    public string? ServerType { get; set; }

    [StringLength(500)]
    public string? ServerDesc { get; set; }
}
