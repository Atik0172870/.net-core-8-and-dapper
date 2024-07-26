using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class AlarmLinkScheduleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleDetailID { get; set; }

        [Required]
        public int ScheduleID { get; set; }

        public int? ScheduleExtraData { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public Guid caObjectID { get; set; }

        public Guid? LastOperator { get; set; }

        public string? LastWorkStation { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }

