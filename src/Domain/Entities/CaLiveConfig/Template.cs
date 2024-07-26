using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Template
{
    [Key]
    [Column(TypeName = "varchar(64)")]
    public string Name { get; set; } = null!;

    public short? RptType { get; set; }

    public short? Period { get; set; }

    public bool? Previous { get; set; }

    [MaxLength(64)]
    public byte[] Filter { get; set; } = null!;

    [MaxLength(512)]
    public byte[] DevList { get; set; } = null!;

    [MaxLength(256)]
    public string Data1 { get; set; } = null!;

    [MaxLength(64)]
    public string Data2 { get; set; } = null!;

    [MaxLength(64)]
    public string Data3 { get; set; } = null!;

    [MaxLength(64)]
    public string Data4 { get; set; } = null!;

    [MaxLength(64)]
    public string Data5 { get; set; } = null!;

    [MaxLength(64)]
    public string Data6 { get; set; } = null!;

    [MaxLength(64)]
    public string Data7 { get; set; } = null!;

    [MaxLength(64)]
    public string Data8 { get; set; } = null!;

    [MaxLength(64)]
    public string Data9 { get; set; } = null!;

    [MaxLength(64)]
    public string Data10 { get; set; } = null!;

    // Properties Data11 to Data44 omitted for brevity

    [Required]
    public int CompanyId { get; set; }
}
