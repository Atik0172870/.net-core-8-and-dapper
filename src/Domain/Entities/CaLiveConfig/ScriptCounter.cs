using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class ScriptCounter
{
    [Required]
    [MaxLength(512)]
    public string CounterName { get; set; } = null!;

    [Required]
    public int CounterVal { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
