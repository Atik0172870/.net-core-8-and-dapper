using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaImageInfo
{
    [Key]
    [Column("Image_ID")]
    public int ImageId { get; set; }

    [Column("Image_Name")]
    public string ImageName { get; set; } = null!;

    [Column("Image_Format_Scheme")]
    public int ImageFormatScheme { get; set; }

    [Column("Image_Max_Size")]
    public int? ImageMaxSize { get; set; }

    [Column("Image_Format")]
    public int? ImageFormat { get; set; }

    [Column("Image_Format_BitDepth")]
    public int? ImageFormatBitDepth { get; set; }

    [Column("Image_Format_Quality")]
    public int? ImageFormatQuality { get; set; }

    [Column("Image_Format_Subsample")]
    public int? ImageFormatSubsample { get; set; }

    [Column("Image_Aspect_X")]
    public int? ImageAspectX { get; set; }

    [Column("Image_Aspect_Y")]
    public int? ImageAspectY { get; set; }

    [Column("Image_Thumbnail_Width")]
    public int? ImageThumbnailWidth { get; set; }

    [Column("Image_Thumbnail_Height")]
    public int? ImageThumbnailHeight { get; set; }

    [Column("Image_Storage_Scheme")]
    public int ImageStorageScheme { get; set; }

    [Column("Image_Storage_Path")]
    public string? ImageStoragePath { get; set; }

    [Column("Image_Storage_AutoSubDirs")]
    public int? ImageStorageAutoSubDirs { get; set; }
}
