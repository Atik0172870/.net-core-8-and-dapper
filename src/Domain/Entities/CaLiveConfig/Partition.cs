using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Partition
{
    [Key]
    public Guid PartitionID { get; set; }

    [Required]
    [MaxLength(50)]
    public string PartitionName { get; set; } = null!;

    [Required]
    public int DeviceType { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
