using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class AlarmLinkSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        public string? ScheduleName { get; set; }

        [Required]
        public bool IsScheduleEventDependent { get; set; }

        [Required]
        public int ScriptID { get; set; }

        [Required]
        public bool ScheduleEnabled { get; set; }

        [Required]
        public int ScheduleTypeID { get; set; }

        [Required]
        public DateTime ScheduleDateTime { get; set; }

        [Required]
        public Guid caObjectID { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public bool RunIfOperatorLoggedOn { get; set; }

        [Required]
        public int cat { get; set; }

        [Required]
        public int pnlNo { get; set; }

        [Required]
        public int DeviceNo { get; set; }

        [Required]
        public int status { get; set; }

        [Required]
        public int facility { get; set; }

        [Required]
        public long Badge { get; set; }

        [Required]
        public int workstationID { get; set; }

        public Guid? LastOperator { get; set; }

        public string? LastWorkStation { get; set; }

        [Required]
        public int EventClassID { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public DateTime? ScheduleDateTimeEnd { get; set; }
    }

