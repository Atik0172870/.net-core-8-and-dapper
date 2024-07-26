using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Reader
{
    [Required]
    public int PnlRef { get; set; }

    [Required]
    public int RdrNo { get; set; }

    [Required]
    [StringLength(100)]
    public string ReaderName { get; set; } = null!;

    [MaxLength]
    public string? Description { get; set; }

    public bool? Enabled { get; set; }

    public bool? RptByp { get; set; }

    public bool? BypUnlock { get; set; }

    public bool? OpnWait { get; set; }

    public int? NoOTL { get; set; }

    public bool? NoXact { get; set; }

    public bool? Escort { get; set; }

    public int? ManRule { get; set; }

    public bool? ExtShunt { get; set; }

    public bool? TZOvr { get; set; }

    public bool? APBOvr { get; set; }

    public bool? Keypad { get; set; }

    public bool? NoDuress { get; set; }

    public bool? CRForced { get; set; }

    public bool? CROtl { get; set; }

    public bool? CRDuress { get; set; }

    public bool? CRTrack { get; set; }

    public bool? CRVoid { get; set; }

    public bool? CRApb { get; set; }

    public bool? CRDenied { get; set; }

    public int? Ctz { get; set; }

    public int? Cctz { get; set; }

    public int? Cytz { get; set; }

    public int? Fatz { get; set; }

    public int? Fdd { get; set; }

    public int? Otl { get; set; }

    public int? Dst { get; set; }

    public int? APBType { get; set; }

    public int? TAType { get; set; }

    public int? LockCtl { get; set; }

    public int? Sensor { get; set; }

    public int? Strike { get; set; }

    public int? Bypass { get; set; }

    public int? Shunt { get; set; }

    public int? DurUse { get; set; }

    public int? Cyph { get; set; }

    public int? Type { get; set; }

    public int? MapId { get; set; }

    [StringLength(23)]
    public string? DeviceId { get; set; }

    public int? DegrSchedule { get; set; }

    public int? ShuntTime { get; set; }

    public int? ManualPriv { get; set; }

    public int? TagTimeout { get; set; }

    public int? APBEntry { get; set; }

    public int? APBExit { get; set; }

    public int? CatCode { get; set; }

    public int? CatFilter { get; set; }

    public int? RepeatOTL { get; set; }

    public int? OTLSchedule { get; set; }

    public int? NAPCOAreas { get; set; }

    [StringLength(50)]
    public string? Location { get; set; }

    [MaxLength]
    public string? Remarks { get; set; }

    public bool? BypCatControl { get; set; }

    public bool? RespForcedDoor { get; set; }

    public bool? RespOTL { get; set; }

    public bool? RespDuress { get; set; }

    public bool? RespTrackedBadge { get; set; }

    public bool? RespVoidBadge { get; set; }

    public bool? RespAPBViolate { get; set; }

    public bool? RespOtherDenied { get; set; }

    public bool? RespBypass { get; set; }

    public bool? RespFreeAccess { get; set; }

    public bool? RespManualDoorCtrl { get; set; }

    public bool? RespCommonCode { get; set; }

    public bool? RespValidAccess { get; set; }

    public bool? AckBypass { get; set; }

    public bool? AckFreeAccess { get; set; }

    public bool? AckManualDoorCtrl { get; set; }

    public bool? AckCommonCode { get; set; }

    public bool? AckValidAccess { get; set; }

    public int? TAAPBType { get; set; }

    public int? CatSchedule { get; set; }

    public Guid? DvrServerID { get; set; }

    public int? DvrCameraID { get; set; }

    public int? VideoPriorityFrom { get; set; }

    public int? VideoPriorityTo { get; set; }

    public int? VideoStartTime { get; set; }

    public int? VideoEndTime { get; set; }

    public bool? EnableRecording { get; set; }

    public int? NoofSecsToRecord { get; set; }

    [Required]
    public bool EnablePTZPreset { get; set; }

    [Required]
    public int PTZPresetNo { get; set; }

    public int? RecordingSchedule { get; set; }

    public int? BadgeUseRegister { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    public bool? NoSound { get; set; }

    public int? AperioAddr { get; set; }

    public bool? DoubleReadFA { get; set; }

    public bool? BypassLocks { get; set; }

    public bool? RexOption { get; set; }

    public bool? UseLedBar { get; set; }

    public int? ElevServerId { get; set; }

    public bool? GenerateAlert { get; set; }

    public int? CompanyId { get; set; }

    public int? DoubleTapMode { get; set; }

    public bool? LockSoundClickEnabled { get; set; }

    public bool? DisableArchitectBtn { get; set; }

    public bool? ToggleMode { get; set; }

    public bool? PrivacyMode { get; set; }

    public int? PrivacyTimeout { get; set; }

    [StringLength(8)]
    public string? BluetoothMac { get; set; }

    public int? OSDPAddr { get; set; }

    public bool? AtmMode { get; set; }
}
