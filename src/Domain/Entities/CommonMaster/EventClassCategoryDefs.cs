using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CardAccess.Domain.Entities.CommonMaster;

#nullable enable
[Table("EventClassCategoryDefs")]
public class EventClassCategoryDefs
{
    [Key]
    public int EventClassCatID { get; set; }

    [Required]
    [StringLength(50)]
    public string EventClassCatName { get; set; } = null!;

    [StringLength(50)]
    public string? LangEventClassCatName { get; set; }
    
    [Required]
    public Guid caObjectID { get; set; } = Guid.NewGuid();
}
