using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MessageTemplates
{
    [Key]
    public int templateID { get; set; }

    [Required]
    [StringLength(50)]
    public string subject { get; set; } = null!;

    public string? body { get; set; }

    [Required]
    public bool allowSNPP { get; set; }

    [Required]
    public bool allowEmail { get; set; }

    [Required]
    public bool allowSMS { get; set; }

    [Required]
    public int include { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public Guid LastOperator { get; set; }

    [Required]
    public Guid caObjectID { get; set; }
}
