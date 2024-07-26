using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaImage
{
    [Key]
    [Column("PersonID")]
    public Guid PersonId { get; set; }

    [Key]
    [Column("Image_Type")]
    public int ImageType { get; set; }

    [Column("Total_size")]
    public int? TotalSize { get; set; }

    [Column("Blob_Segment")]
    public byte[]? BlobSegment { get; set; }
}
