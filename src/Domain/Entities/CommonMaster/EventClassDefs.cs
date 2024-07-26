using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("EventClassDefs")]

public class EventClassDefs
{
    [Key]
    [Column(Order = 0)]
    public int EventClassID { get; set; }

    [StringLength(50)]
    public string? EventClassName { get; set; }

    [StringLength(50)]
    public string? EventDescription { get; set; }

    [StringLength(50)]
    public string? MenuKey { get; set; }

    public int? Status { get; set; }

    public int? DeviceCode { get; set; }

    public int? DeviceFilter1 { get; set; }

    public int? DeviceFilter2 { get; set; }

    [Key]
    [Column(Order = 1)]
    public int EventClassCategoryID { get; set; }

    public int? EventCode { get; set; }

    [StringLength(50)]
    public string? LangEventClassName { get; set; }

    [StringLength(50)]
    public string? LangEventDescription { get; set; }

    public int? PanelStatus { get; set; }

    public int? PriorityIndex { get; set; }

    // ForeignKey constraint
    [ForeignKey("EventClassID, EventClassCategoryID")]
    public EventClassDefs? ParentEventClass { get; set; }
}
