using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Map
{
    [Key]
    public Guid MapUID { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MapID { get; set; }

    public string MapName { get; set; } = null!;

    public string MapDescription { get; set; } = null!;

    public byte[] MapImage { get; set; } = null!;

    [Required]
    public Guid caObjectID { get; set; }

    public int? MapWidth { get; set; }

    public int? MapHeight { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string LastWorkStation { get; set; } = null!;

    public byte[] Snapshot { get; set; } = [];

    [Required]
    public int CompanyId { get; set; }
}

