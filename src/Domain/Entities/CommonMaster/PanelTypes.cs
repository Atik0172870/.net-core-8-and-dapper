using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("Panel_Types")]
public class PanelTypes
{
    [Key]
    public int ID { get; set; } = 0;

    [StringLength(50)]
    public string? Description { get; set; }

    public int? MaxReaders { get; set; }

    public int? MaxInputs { get; set; }

    public int? MaxRelays { get; set; }

    public int? MaxPhysicalInputs { get; set; }

    public int? MaxPhysicalRelays { get; set; }

    public int? PanelGeneration { get; set; }
}
