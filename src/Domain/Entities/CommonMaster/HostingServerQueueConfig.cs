using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


public class HostingServerQueueConfig
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public int? QueueId { get; set; }

    public int? ServerId { get; set; }

    public bool? IsReader { get; set; }

    [ForeignKey("QueueId")]
    public virtual HostingQueueConfig HostingQueueConfig { get; set; } = null!;

    [ForeignKey("ServerId")]
    public virtual HostingServerConfig HostingServerConfig { get; set; } = null!;
}
