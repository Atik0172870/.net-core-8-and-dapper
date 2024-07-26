using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("MapDisplayIcon")]
public class MapDisplayIcon
{
    [Key]
    [Column(Order = 0)]
    public int MapDisplayIconID { get; set; }

    public int? EventCode { get; set; }

    public byte[]? DefaultIcon { get; set; }

    public byte[]? DisplayIcon { get; set; }

    [StringLength(255)]
    public string? EventName { get; set; }

    public int? DeviceCode { get; set; }

    [StringLength(255)]
    public string? LangEventName { get; set; }

    [Key]
    [Column(Order = 1)]
    public int CompanyId { get; set; }
}
