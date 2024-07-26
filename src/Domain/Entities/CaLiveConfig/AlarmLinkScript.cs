using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class AlarmLinkScript
{
    [Key]
    public int ScriptID { get; set; }

    [MaxLength(50)]
    public string? ScriptName { get; set; }

    [Required]
    [MaxLength(255)]
    public string procName { get; set; } = null!;

    public string? ScriptText { get; set; }

    [Required]
    [MaxLength(50)]
    public string scriptLanguage { get; set; } = null!;

    public string? CompiledScript { get; set; }

    [Required]
    public bool generateEvent { get; set; }

    [Required]
    public int executeEventPriority { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public string ScreenObject { get; set; } = null!;
}
