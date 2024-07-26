using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class SnppProvider
{
    [Key]
    public int SnppHostID { get; set; }

    [Required]
    [MaxLength(50)]
    public string SnppHostName { get; set; } = null!;

    [MaxLength(255)]
    public string SnppServer { get; set; } = null!;

    public int? SnppPort { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public Guid CaObjectID { get; set; }
}
