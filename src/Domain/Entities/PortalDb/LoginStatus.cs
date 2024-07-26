using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("LoginStatus")]
public class LoginStatus
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long UserId { get; set; }

    public bool Status { get; set; }

    public DateTime LoginTime { get; set; }

    public DateTime LastUpdated { get; set; }

    [StringLength(50)]
    public string? Browser { get; set; }

    [StringLength(50)]
    public string? Platform { get; set; }

    [StringLength(50)]
    public string? Version { get; set; }

    public bool IsMobileDevice { get; set; }

    public int? UTCOffset { get; set; }
}
