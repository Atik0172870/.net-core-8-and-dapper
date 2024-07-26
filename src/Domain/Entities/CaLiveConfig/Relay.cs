using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Relay
{
    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int RelNo { get; set; }

    [Required]
    public string RelayName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Enabled { get; set; }

    public bool? XactRpt { get; set; }

    public bool? Dialup { get; set; }

    public bool? NormOn { get; set; }

    public int? RelTime { get; set; }

    public int? TrackTz { get; set; }

    public int? Priority { get; set; }

    public int? MapId { get; set; }

    public string? DeviceId { get; set; }

    public bool? RespReq { get; set; }

    public int? ManualPriv { get; set; }

    public string? Location { get; set; }

    public string? Remarks { get; set; }

    public Guid? caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
