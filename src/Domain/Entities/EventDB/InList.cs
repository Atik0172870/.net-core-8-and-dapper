using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("InList")]
public class InList
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InListID { get; set; }

    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Guid PersonID { get; set; }

    [Required]
    public long Badge { get; set; }

    [Required]
    public int Facility { get; set; }

    [MaxLength(64)]
    public string? Reader { get; set; }

    public int? PnlNo { get; set; }

    public int? RdrNo { get; set; }

    public int? APBArea { get; set; }

    public bool? APBIn { get; set; }

    public bool? TAin { get; set; }

    public DateTime? PanelTime { get; set; }

    public int? UTCOffset { get; set; }

    public int? ZoneId { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
