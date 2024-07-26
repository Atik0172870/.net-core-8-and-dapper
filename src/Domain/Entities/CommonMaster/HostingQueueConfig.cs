using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("HostingQueueConfig")]
public class HostingQueueConfig
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(200)]
    public string? QueueName { get; set; }

    public long? ReceiveTimeoutInSec { get; set; }

    public int? PanelType { get; set; }

    [StringLength(200)]
    public string? QueuePath { get; set; }

    public bool? AllowTransaction { get; set; }
}
