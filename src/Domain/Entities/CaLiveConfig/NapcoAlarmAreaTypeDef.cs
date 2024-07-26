using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoAlarmAreaTypeDef
{
    [Key]
    public int AlarmAreaType { get; set; }

    [StringLength(50)]
    public string? AreaTypeName { get; set; }

    [Required]
    public Guid caObjectID { get; set; }
}
