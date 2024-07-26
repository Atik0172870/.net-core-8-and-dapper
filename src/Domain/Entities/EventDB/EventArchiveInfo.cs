using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("EventArchiveInfo")]
public class EventArchiveInfo
{
    [Key]
    public Guid ID { get; set; } = Guid.NewGuid();

    public DateTime? ArchiveDate { get; set; } = DateTime.UtcNow;

    [MaxLength(150)]
    public string? ArchiveServer { get; set; }

    [MaxLength(150)]
    public string? ArchiveDB { get; set; }

    public long? EventCount { get; set; } = 0;

    [MaxLength(10)]
    public string? ArchiveType { get; set; }
}
