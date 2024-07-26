using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class OperatorPartition
{
    [Key]
    public Guid PartitionID { get; set; }

    [Key]
    public Guid OperatorID { get; set; }

    [Required]
    public bool IsPrimaryPartition { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }
}
