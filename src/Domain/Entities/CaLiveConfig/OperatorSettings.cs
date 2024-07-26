using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class OperatorSettings
{
    [Key]
    public Guid OperatorID { get; set; }

    public int? GUIViewMode { get; set; }

    public int? UIViewStyle { get; set; }

    public int? LanguageID { get; set; }

    public bool? MapManualControlDblClick { get; set; }

    [MaxLength(50)]
    public string? MapToolTipInterval { get; set; }

    public bool? MapCloseAlert { get; set; }

    [MaxLength(50)]
    public string? MapTheme { get; set; }

    public int? StatusUpdateInterval { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }
}
