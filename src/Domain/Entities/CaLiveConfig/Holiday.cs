using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Holiday
{
    [Key]
    public int CalendarNo { get; set; }

    [Key]
    public int HolNo { get; set; }

    public DateTime? SDate { get; set; }

    public int? FrHr { get; set; }

    public int? FrMin { get; set; }

    public int? EndHr { get; set; }

    public int? EndMin { get; set; }

    public DateTime? FromTime { get; set; }

    public DateTime? ToTime { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
