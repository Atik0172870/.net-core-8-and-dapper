using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("Screens")]
public class Screen
{
    [Key]
    public int ScreenID { get; set; }

    [Required]
    [StringLength(100)]
    public string ScreenName { get; set; } = null!;

    [StringLength(1024)]
    public string? PluginAssembly { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }
}
