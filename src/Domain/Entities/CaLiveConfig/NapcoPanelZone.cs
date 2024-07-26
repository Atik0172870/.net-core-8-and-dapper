using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanelZone
{
    [Key]
    public int AlarmPanelID { get; set; }

    [Key]
    public int ZoneNumber { get; set; }

    [Required]
    public int AreaNumber { get; set; }

    [Required]
    public bool ZoneConfigured { get; set; }

    [MaxLength(50)]
    public string? ZoneName { get; set; }

    public Guid? DvrServerID { get; set; }

    public int? DvrCameraID { get; set; }

    public int? VideoStartTime { get; set; }

    public int? VideoEndTime { get; set; }

    public int? VideoPriorityFrom { get; set; }

    public int? VideoPriorityTo { get; set; }

    public bool? EnableRecording { get; set; }

    public int? NoofSecsToRecord { get; set; }

    public int? RecordingSchedule { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? MapId { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
