using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Panel
{
    [Key]
    public int PnlNo { get; set; }

    [Required]
    [MaxLength(50)]
    public string PanelName { get; set; } = null!;

    [MaxLength]
    public string? Description { get; set; }

    public int Address { get; set; }

    public int? ComPort { get; set; }

    public int? HCSNo { get; set; }

    public bool? Enabled { get; set; }

    public bool? Interactive { get; set; }

    public bool? NoFail { get; set; }

    public int? XactSize { get; set; }

    public int? Node { get; set; }

    public int? MapId { get; set; }

    [MaxLength(23)]
    public string? DeviceId { get; set; }

    public int? CommPrior { get; set; }

    public int? DwnLoadPrior { get; set; }

    public int? PwrPrior { get; set; }

    public int? Schedules { get; set; }

    [Required]
    public bool Elevators { get; set; }

    public int? ModemPrior { get; set; }

    public int? LowBatPrior { get; set; }

    public bool? Passwrd { get; set; }

    public int? CurrentPwd { get; set; }

    public bool? DegradeMode { get; set; }

    public int? AGSize { get; set; }

    [MaxLength(50)]
    public string? Location { get; set; }

    [MaxLength]
    public string? Remarks { get; set; }

    public int? PanelType { get; set; }

    public int? MaxAlp { get; set; }

    public int? MaxEvt { get; set; }

    public int? DefaultCalendar { get; set; }

    public int? NAPCOPanel { get; set; }

    public bool? NoPolling { get; set; }

    public bool? RespOffOnLine { get; set; }

    public bool? RespDownloads { get; set; }

    public bool? RespACPowerFail { get; set; }

    public bool? RespModemActivity { get; set; }

    public bool? RespLowBattery { get; set; }

    public Guid? caObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? ZoneId { get; set; }

    public int? UTCOffset { get; set; }

    [MaxLength(50)]
    public string? LockId { get; set; }

    public int? LockUpdateSchedule { get; set; }

    public int? LockType { get; set; }

    public int? LockAssigned { get; set; }

    public bool? LockChanged { get; set; }

    [Required]
    public bool RemoteDevice { get; set; }

    public int CentralStationId { get; set; }

    public int? RetrievalSchedule { get; set; }

    public bool? AperioType { get; set; }

    public int? LockExpAddress { get; set; }

    public int? EleControlType { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public int ComPortAddress { get; set; }

    public bool? OSDPReaderClock { get; set; }

    public int? OSDPReader { get; set; }

    [MaxLength(32)]
    public string? OSDPKey { get; set; }

    public int? OSDPBaudRate { get; set; }

    public bool? FreeAccessExitBolt { get; set; }
}
