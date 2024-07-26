using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("ALPEventTypes")]
public class ALPEventType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EventCode { get; set; }

    public int? EventCat { get; set; }

    [StringLength(48)]
    public string? Description { get; set; }

    [StringLength(48)]
    public string? LangEventDescription { get; set; }

    [Required]
    public Guid CaObjectId { get; set; } = new Guid();
}
