using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RolePlugin
{
    [Required]
    public Guid RoleID { get; set; }

    [Required]
    public Guid PluginId { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
