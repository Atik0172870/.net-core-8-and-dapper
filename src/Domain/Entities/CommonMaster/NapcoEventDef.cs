using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("napcoEventDef")]
public class NapcoEventDef
{
    [Key]
    [StringLength(2)]
    public string StatusCode { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string EventMsgText { get; set; } = string.Empty;

    [StringLength(100)]
    public string? LangEventMsgText { get; set; }

    public int EventHandlerType { get; set; } = 0;

    public bool DefaultGenerateEvent { get; set; } = false;

    public int DefaultEventPriority { get; set; } = 50;

    public bool DefaultResponseRequired { get; set; } = false;

    public int DeviceStatus { get; set; } = -1;
}
