using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class SmsProvider
{
    [Key]
    public int SmsHostID { get; set; }

    [Required]
    [MaxLength(50)]
    public string SmsHostName { get; set; } = null!;

    [MaxLength(255)]
    public string SmsServer { get; set; } = null!;

    public int? SmsType { get; set; }

    [MaxLength(255)]
    public string SmsParams { get; set; } = null!;

    [MaxLength(50)]
    public string SmsPassword { get; set; } = null!;

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    [Required]
    public Guid CaObjectID { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
