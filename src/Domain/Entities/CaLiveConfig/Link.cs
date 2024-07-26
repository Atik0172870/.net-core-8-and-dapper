using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Link
{
    [Key]
    public int PnlRef { get; set; }

    [Key]
    public int ProgNo { get; set; }

    public bool? Enabled { get; set; }

    public bool? Dialup { get; set; }

    public bool? RptXact { get; set; }

    [Required]
    [MaxLength(100)]
    public string LinkName { get; set; } = null!;

    public string? Description { get; set; }

    public int? Status { get; set; }

    public int? LnkPnl { get; set; }

    public int? LnkProg { get; set; }

    public int? ETz { get; set; }

    public int? TrkTZ { get; set; }

    public int? Inp1 { get; set; }

    public int? Inp2 { get; set; }

    public int? Inp3 { get; set; }

    public int? Inp4 { get; set; }

    public int? Inp5 { get; set; }

    public int? On1 { get; set; }

    public int? On2 { get; set; }

    public int? On3 { get; set; }

    public int? On4 { get; set; }

    public int? On5 { get; set; }

    public int? Off1 { get; set; }

    public int? Off2 { get; set; }

    public int? Off3 { get; set; }

    public int? Off4 { get; set; }

    public int? Off5 { get; set; }

    public int? Trk1 { get; set; }

    public int? Trk2 { get; set; }

    public int? Trk3 { get; set; }

    public int? Trk4 { get; set; }

    public int? Trk5 { get; set; }

    public int? Priority { get; set; }

    public int? MapId { get; set; }

    public string? DeviceId { get; set; }

    public bool? RespReq { get; set; }

    public int? ManualPriv { get; set; }

    [MaxLength(50)]
    public string? Location { get; set; }

    public string? Remarks { get; set; }

    public Guid? caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
