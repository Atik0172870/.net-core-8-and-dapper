using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RepeaterStatus
{
    [Required]
    public int Cluster { get; set; }

    [Required]
    public int ComPort { get; set; }

    [Required]
    public int rfAddress { get; set; }

    public string? Id { get; set; }

    public int? RouteIn { get; set; }

    public int? RouteOut { get; set; }

    public int? State { get; set; }

    public int? RSSI { get; set; }

    public int? FirmwareMajor { get; set; }

    public int? FirmwareMinor { get; set; }

    public int? Status { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int ComPortAddress { get; set; }
}
