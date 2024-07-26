using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("AppGlobalSetting")]
public class AppGlobalSetting
{
    [Key]
    [StringLength(50)]
    public string Key { get; set; } = null!;

    public string? Value { get; set; }

    public bool? Enabled { get; set; }

    public int? Option { get; set; }

    [StringLength(1000)]
    public string? Remarks { get; set; }
}
