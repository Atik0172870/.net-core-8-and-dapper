using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NotificationMessagingEvents
{
    [Key]
    public int PnlNo { get; set; }

    [Key]
    public int DeviceType { get; set; }

    [Key]
    public int DeviceNo { get; set; }

    public int CompanyId { get; set; }

    public int? EventClassId { get; set; }

    public int? Cat { get; set; }

    public int? Status { get; set; }

    [Key]
    public Guid NotificationMessagingId { get; set; }
}
