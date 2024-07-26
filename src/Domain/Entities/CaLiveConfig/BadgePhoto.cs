using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class BadgePhoto
{
    [Key]
    [Column(Order = 0)]
    public Guid PersonID { get; set; }

    [Key]
    [Column(Order = 1)]
    public int ImageTypeID { get; set; }

    [Required]
    public byte[] BadgeImage { get; set; } = [];

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public Guid? LastOperator { get; set; }

    [Timestamp]
    public byte[]? LastUpdates { get; set; }
}
