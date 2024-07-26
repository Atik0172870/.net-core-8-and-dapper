using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class WorkStationSettings
{
    [Key]
    public string WorkstationName { get; set; } = null!;
    public bool? UsePrinting { get; set; }
    public string EventPrn { get; set; } = null!;
    public string BadgingPrn { get; set; } = null!;
    public bool? UseBadging { get; set; }
    public bool? EnableVideoService { get; set; }
    public bool? UseWirelessLocks { get; set; }
    public int? Badgingoption { get; set; }
    public bool? UseAlertSound { get; set; }
    public int? AlertSoundInterval1 { get; set; }
    public int? AlertSoundInterval2 { get; set; }
    public int? AlertSoundInterval3 { get; set; }
    public int? AlertSoundInterval4 { get; set; }
    public int? ResponseSoundInterval { get; set; }
    public int? AlertSoundPriority1 { get; set; }
    public int? AlertSoundPriority2 { get; set; }
    public int? AlertSoundPriority3 { get; set; }
    public int? AlertSoundPriority4 { get; set; }
    public string AlertColor1 { get; set; } = null!;
    public string AlertColor2 { get; set; } = null!;
    public string AlertColor3 { get; set; } = null!;
    public string AlertColor4 { get; set; } = null!;
    public string TapiPhone1 { get; set; } = null!;
    public string TapiPhone2 { get; set; } = null!;
    public string TapiId1 { get; set; } = null!;
    public string TapiId2 { get; set; } = null!;
    public bool? CCTVSocket { get; set; }
    public bool? UseLinePrinterMode { get; set; }
    public string EventPrinter { get; set; } = null!;
    public int? PhotoViewMode { get; set; }
    public int? VideoView { get; set; }
    public int? MapView { get; set; }
    public bool? SoftwareElevCtrl { get; set; }
    public Guid caObjectID { get; set; }
    public DateTime LastUpdated { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
    public int? SoundIndex1 { get; set; }
    public int? SoundIndex2 { get; set; }
    public int? SoundIndex3 { get; set; }
    public int? SoundIndex4 { get; set; }
    public int? ResponseSoundIndex { get; set; }
}
