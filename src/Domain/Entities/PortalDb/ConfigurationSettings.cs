using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("ConfigurationSettings")]
public class ConfigurationSettings
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? LiveConfigServer { get; set; }

    [StringLength(100)]
    public string? LiveConfigDB { get; set; }

    [StringLength(100)]
    public string? LiveEventServer { get; set; }

    [StringLength(100)]
    public string? LiveEventDB { get; set; }

    [StringLength(50)]
    public string? DatabaseUserName { get; set; }

    [StringLength(50)]
    public string? DatabasePassword { get; set; }

    [StringLength(100)]
    public string? ComServer { get; set; }

    [StringLength(100)]
    public string? ComDB { get; set; }
}
