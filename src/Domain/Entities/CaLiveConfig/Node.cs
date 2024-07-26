using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Node
{
    public int NodeId { get; set; }

    [Required]
    public string NodeName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public int? HCSNo { get; set; }

    public int? Schedule { get; set; }

    public int? Frequency { get; set; }

    public string? Setup1 { get; set; }

    public string? Setup2 { get; set; }

    public int? DevIdIn { get; set; }

    public int? DevIdOut { get; set; }

    public int? Status { get; set; }

    public string? HostPhone1 { get; set; }

    public string? HostPhone2 { get; set; }

    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    [Required]
    public Guid CaObjectId { get; set; }

    public int? UTCOffset { get; set; }

    public int CompanyId { get; set; }
}
