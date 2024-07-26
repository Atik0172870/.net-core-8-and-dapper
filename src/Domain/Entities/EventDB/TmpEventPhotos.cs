using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("tmpEventPhotos")]
public class TmpEventPhotos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PhotoID { get; set; }

    public Guid Seqno { get; set; }

    public DateTime? PhotoDate { get; set; }

    public int? StationID { get; set; }

    public int? OpNo { get; set; }

    public int? CctvID { get; set; }

    [Column(TypeName = "varbinary(max)")]
    public byte[] PhotoData { get; set; } = null!;
}
