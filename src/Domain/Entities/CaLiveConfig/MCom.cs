using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class MCom
{
    [Key]
    public int HCSNo { get; set; }

    public string Description { get; set; } = null!;

    public string UNCName { get; set; } = null!;

    public bool? IsAssigned { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    public string LastWorkStation { get; set; } = null!;
}
