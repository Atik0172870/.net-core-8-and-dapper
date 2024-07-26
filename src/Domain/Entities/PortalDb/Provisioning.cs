using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("Provisioning")]
public class Provisioning
{
    [Key]
    [StringLength(20)]
    public string ICCID { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime? LastUpdated { get; set; } = DateTime.Now;
}

