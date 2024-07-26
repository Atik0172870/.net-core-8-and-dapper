using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class BadgeCategory
    {
        [Key]
        [Column(Order = 0)]
        public long Badge { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Facility { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CatNumber { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [StringLength(50)]
        public string? LastWorkstation { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
