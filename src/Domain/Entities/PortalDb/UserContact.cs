using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("UserContact")]
    public class UserContact
    {
        [Key]
        public long Id { get; set; }

        public long? UserId { get; set; }

        [StringLength(500)]
        public string? Address1 { get; set; }

        [StringLength(500)]
        public string? Address2 { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        public int? State { get; set; }

        [StringLength(10)]
        public string? Zip { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        [StringLength(20)]
        public string? Landline { get; set; }

        [StringLength(20)]
        public string? LandlineExt1 { get; set; }

        [StringLength(20)]
        public string? LandlineExt2 { get; set; }

        [StringLength(20)]
        public string? Fax { get; set; }

        [StringLength(20)]
        public string? FaxExt { get; set; }

        [StringLength(20)]
        public string? CellNumber { get; set; }

        public DateTime? LastUpdated { get; set; }

        [StringLength(50)]
        public string? LastOperator { get; set; }

        [StringLength(50)]
        public string? LastWorkStation { get; set; }

        public int? UTCOffset { get; set; }

        public bool? PrimaryContact { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }
    }
