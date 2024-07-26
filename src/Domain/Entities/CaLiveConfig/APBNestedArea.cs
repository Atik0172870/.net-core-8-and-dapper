using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class APBNestedArea
    {
        [Key]
        public int Node { get; set; }

        [Key]
        public int AreaNo { get; set; }

        public string? NestName { get; set; }

        public int? Level { get; set; }

        [Required]
        public int Parent { get; set; }

        public Guid? caObjectId { get; set; }

        public DateTime? LastUpdated { get; set; }

        public Guid? LastOperator { get; set; }

        public string? LastWorkstation { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
