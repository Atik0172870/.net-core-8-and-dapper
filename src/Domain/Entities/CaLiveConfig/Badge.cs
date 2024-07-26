using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Badge
    {
        [Key]
        public Guid PersonID { get; set; }

        [Key]
        public long BadgeNumber { get; set; }

        [Key]
        public int Facility { get; set; }

        [StringLength(50)]
        public string? PIVI { get; set; }

        public int? Pin { get; set; }

        public int? Issue { get; set; }

        public bool? Enabled { get; set; }

        public bool? Track { get; set; }

        public bool? Resident { get; set; }

        public bool? InitLoad { get; set; }

        public bool? Shunt { get; set; }

        public bool? DurUse { get; set; }

        public bool? Escort { get; set; }

        public int? AccessTime { get; set; }

        public DateTime? ActvDate { get; set; }

        public DateTime? ExprDate { get; set; }

        public int? Embossed { get; set; }

        public int? ShuntId { get; set; }

        public DateTime? SDate { get; set; }

        public int? UseCount { get; set; }

        public bool? VehicleTag { get; set; }

        [StringLength(50)]
        public string? EPI_BadgeID { get; set; }

        [StringLength(10)]
        public string? EPI_FORMAT_ID { get; set; }

        public bool? FirstInControl { get; set; }

        public int? APBArea { get; set; }

        public int? APBSet { get; set; }

        public int? HolidayCalendar { get; set; }

        public bool? MApbExempt { get; set; }

        public int? AgencyCode { get; set; }

        public int? Series { get; set; }

        public long? PersPIVId { get; set; }

        public int? OrgCategory { get; set; }

        public int? OrgId { get; set; }

        public int? OrgAssoc { get; set; }

        public int? SiteNo { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public Guid caObjectID { get; set; }

        public Guid? LastOperator { get; set; }

        [StringLength(50)]
        public string? LastWorkStation { get; set; }

        public int? UTCOffset { get; set; }

        public bool? Flag { get; set; }

        [Required]
        public int BadgeType { get; set; }

        [Required]
        public int NAPCOPermissionId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public bool? SuppressDoubleTap { get; set; }

        public bool? DisableCommonCode { get; set; }
    }
