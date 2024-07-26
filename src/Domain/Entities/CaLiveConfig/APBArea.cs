using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class APBArea
    {
        [Key]
        public int AreaNo { get; set; }

        public string? Description { get; set; }

        public int? ParentArea { get; set; }

        public bool? AlertOn { get; set; }

        public int? LinkVacant { get; set; }

        public int? LinkOccupied { get; set; }

        public int? AreaCountUp { get; set; }

        public int? LinkOnCountUp { get; set; }

        public int? AreaCountDown { get; set; }

        public int? LinkOnCountDown { get; set; }

        public bool? Active { get; set; }

        public Guid caObjectID { get; set; }

        public DateTime LastUpdated { get; set; }

        public Guid? LastOperator { get; set; }

        public string? LastWorkStation { get; set; }

        public bool? Schedlocked { get; set; }

        public int CompanyId { get; set; }
    }
