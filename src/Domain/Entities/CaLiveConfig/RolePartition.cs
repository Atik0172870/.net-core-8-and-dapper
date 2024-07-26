using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RolePartition
{
    [Required]
    public Guid PartitionID { get; set; }

    [Required]
    public Guid RoleID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public bool IsPrimaryPartition { get; set; }
}
