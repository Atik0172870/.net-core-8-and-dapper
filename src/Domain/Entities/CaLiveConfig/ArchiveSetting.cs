using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ArchiveSetting
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ArchiveConfigServer { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string ArchiveConfigDatabase { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string ArchiveEventsServer { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string ArchiveEventsDatabase { get; set; } = null!;

    [Required]
    public long DBFileSize { get; set; }

    [Required]
    public int FullDBFileSize { get; set; }

    [Required]
    public long EventsToRetain { get; set; }

    [Required]
    public long EventsInArchiveDatabase { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }
}
