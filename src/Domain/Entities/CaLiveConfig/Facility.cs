using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Facility
{
    [Key]
    public int PnlRef { get; set; }

    public int? Facil1 { get; set; }
    public int? Facil2 { get; set; }
    public int? Facil3 { get; set; }
    public int? Facil4 { get; set; }
    public int? Facil5 { get; set; }
    public int? Facil6 { get; set; }
    public int? Facil7 { get; set; }
    public int? Facil8 { get; set; }
    public int? Facil9 { get; set; }
    public int? Facil10 { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    public Guid? LastOperator { get; set; }
    public string? LastWorkStation { get; set; }
    public int? UTCOffset { get; set; }

    public int CompanyId { get; set; }
}
