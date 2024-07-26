using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("EventPhotos")]
public class EventPhotos
{
    [Key]
    public Guid PhotoID { get; set; } = Guid.NewGuid();

    public Guid Seqno { get; set; } = Guid.NewGuid();

    public DateTime? PhotoDate { get; set; }

    public int? StationID { get; set; }

    public int? OpNo { get; set; }

    public int? CctvID { get; set; }

    public byte[]? PhotoData { get; set; }
}
