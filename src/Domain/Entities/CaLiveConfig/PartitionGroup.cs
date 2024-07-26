using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class PartitionGroup
{
    [Key]
    public Guid PartGroupID { get; set; }

    [Required]
    public int DeviceType { get; set; }

    [Required]
    [MaxLength(50)]
    public string? PartGroupName { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }
}
