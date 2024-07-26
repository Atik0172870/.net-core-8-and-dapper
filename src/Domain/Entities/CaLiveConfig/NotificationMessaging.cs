using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NotificationMessaging
{
    [Required]
    public int DeviceType { get; set; }

    [Required]
    public int PnlNo { get; set; }

    [Required]
    public int DeviceNo { get; set; }

    public int? Status { get; set; }

    [Required]
    public bool NotificationEnabled { get; set; }

    public Guid? MessageID { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    [Required]
    public Guid CaObjectId { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public int? UTCOffset { get; set; }

    public string? Description { get; set; }
}
