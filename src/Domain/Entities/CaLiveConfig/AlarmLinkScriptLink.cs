using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class AlarmLinkScriptLink
    {
        [Key]
        public int cat { get; set; }

        [Key]
        public int pnlNo { get; set; }

        [Key]
        public int DeviceNo { get; set; }

        [Key]
        public int status { get; set; }

        [Key]
        public int workstationID { get; set; }

        [Key]
        public int facility { get; set; }

        [Key]
        public long badge { get; set; }

        [Key]
        public int scriptID { get; set; }

        [Required]
        [MaxLength(50)]
        public string scriptLinkName { get; set; } = null!;

        [Required]
        public int EventClassID { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public bool scriptLinkEnabled { get; set; }

        [Required]
        public Guid caObjectID { get; set; }

        public Guid? LastOperator { get; set; }

        public string? LastWorkStation { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
