using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Input
{
    [Key]
    public int PnlRef { get; set; }

    [Key]
    public int InpNo { get; set; }

    [Required]
    [MaxLength(100)]
    public string InputName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Enabled { get; set; }

    public bool? NormOpen { get; set; }

    public bool? Supervised { get; set; }

    public bool? NoXact { get; set; }

    public bool? AbnormDial { get; set; }

    public bool? NormDial { get; set; }

    public bool? ConRelay { get; set; }

    public int? InpTz { get; set; }

    public int? InpDelay { get; set; }

    public int? InpReset { get; set; }

    public int? Priority { get; set; }

    public int? MapId { get; set; }

    public string? DeviceId { get; set; }

    public bool? RespReq { get; set; }

    public string? Remark { get; set; }

    [MaxLength(50)]
    public string? Location { get; set; }

    public Guid? DvrServerID { get; set; }

    public int? DvrCameraID { get; set; }

    public int? VideoStartTime { get; set; }

    public int? VideoEndTime { get; set; }

    public int? VideoEventType { get; set; }

    public bool? EnableRecording { get; set; }

    public int? NoofSecsToRecord { get; set; }

    public int? AlertLimit { get; set; }

    public int? LimitSchedule { get; set; }

    public int? PTZPresetNo { get; set; }

    public bool? EnablePTZPreset { get; set; }

    public int? RecordingSchedule { get; set; }

    public int? CatReader { get; set; }

    public int? CatCode { get; set; }

    public int? Categories { get; set; }

    public int? CatSchedule { get; set; }

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
