using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RepeaterDescription
{
    [Required]
    public int Cluster { get; set; }

    [Required]
    public int ComPort { get; set; }

    [Required]
    public int rfAddress { get; set; }

    public string? Description { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int ComPortAddress { get; set; }
}
