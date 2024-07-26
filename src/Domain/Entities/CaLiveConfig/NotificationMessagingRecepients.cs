using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NotificationMessagingRecepients
{
    [Key]
    public int PnlNo { get; set; }

    [Key]
    public int DeviceType { get; set; }

    [Key]
    public int DeviceNo { get; set; }

    public int CompanyId { get; set; }

    public Guid? OperatorId { get; set; }

    public string CustomReceipients { get; set; } = null!;

    public bool? Email { get; set; }

    public bool? SMS { get; set; }

    [Key]
    public Guid caObjectId { get; set; }

    [ForeignKey("NotificationMessaging")]
    public Guid NotificationMessagingId { get; set; }
}
