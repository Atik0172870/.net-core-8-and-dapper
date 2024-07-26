using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("HostingFeeStructure")]
public class HostingFeeStructure
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(100)]
    public string? PlanName { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public string? FeatureList { get; set; }

    public decimal? CostPerReader { get; set; }

    public int? IntervalId { get; set; }

    [ForeignKey("IntervalId")]
    public FeeInterval? Interval { get; set; }
}
