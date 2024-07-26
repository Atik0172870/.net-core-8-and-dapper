using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class BadgeAccess
    {
        [Key]
        [Column(Order = 0)]
        public long Badge { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Facility { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AGroupNo { get; set; }

        public DateTime? AGroupActivationDate { get; set; }

        public DateTime? AGroupExpirationDate { get; set; }

        public bool? PointAccess { get; set; }

        [Key]
        [Column(Order = 3)]
        public int AGSeq { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public Guid caObjectID { get; set; }

        public Guid? LastOperator { get; set; }

        [StringLength(50)]
        public string? LastWorkStation { get; set; }

        public int? UTCOffset { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
