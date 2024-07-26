using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("UserLogo")]
    public class UserLogo
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        public byte[]? Logo { get; set; }

        public DateTime? LastUpdated { get; set; }

        [StringLength(50)]
        public string? LastOperator { get; set; }

        [StringLength(50)]
        public string? LastWorkStation { get; set; }

        public int? UTCOffset { get; set; }
    }
